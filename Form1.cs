﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Utf8Json;

namespace munchkin_card_editor
{
    public partial class MainForm : Form
    {
        string cardpackPath = null;
        CardpackData data = new CardpackData();
        Card[] _cardsEditing;
        Card[] cardsEditing
        {
            get => _cardsEditing;
            set
            {
                if (_cardsEditing != null)
                    foreach (Card card in _cardsEditing)
                        UpdateCardMembers(card);
                _cardsEditing = value;
                UpdateCardDisplayedData();
            }
        }
        Card cardEditing
        {
            get
            {
                if (_cardsEditing == null || _cardsEditing.Length == 0)
                    return null;
                else
                    return _cardsEditing[0];
            }
        }

        public MainForm()
        {
            InitializeComponent();

            foreach (Type style in from type in Assembly.GetExecutingAssembly().GetTypes()
                                   where type != typeof(ICardStyle) && typeof(ICardStyle).IsAssignableFrom(type)
                                   select type)
            {
                cardStyleComboBox.Items.Add(new EncapsulatedCardStyleType(style));
            }
            cardCategoryComboBox.Items.Add(CardCategory.Dungeon);
            cardCategoryComboBox.Items.Add(CardCategory.Treasure);

            RefreshListbox();
        }

        private void RefreshListbox()
        {
            cardListBox.DataSource = null;
            cardListBox.DataSource = data.Cards;
        }

        private void addCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Card card = new Card { Title = "New card", Description = "This is a description" };
            data.Cards.Add(card);
            RefreshListbox();
        }

        private void cardListBoxContextStrip_Opening(object sender, CancelEventArgs e)
        {
            deleteCardCtxItem.Enabled = cardListBox.SelectedItem != null;
        }

        const string multiValueSelectionIndicator = "<Different values>";

        private void UpdateCardMembers(Card card)
        {
            Console.WriteLine("Updated members of " + card.ToString());
            if (card == null) return;

            if (cardTitleTextBox.Text != multiValueSelectionIndicator)
                card.Title = cardTitleTextBox.Text;
            if (cardDescriptionTextBox.Text != multiValueSelectionIndicator)
                card.Description = cardDescriptionTextBox.Text;
            if (cardScriptComboBox.Text != multiValueSelectionIndicator)
                card.ScriptPath = cardScriptComboBox.Text;
            card.Category = (CardCategory)cardCategoryComboBox.SelectedItem;
            if (cardStyleComboBox.SelectedItem != null)
                card.Style = (ICardStyle)Activator.CreateInstance(((EncapsulatedCardStyleType)cardStyleComboBox.SelectedItem).Type);
        }

        private void UpdateDisplayedImage()
        {
            Card card = cardEditing;
            if (card == null) return;

            Card preview = new Card
            {
                Title = cardTitleTextBox.Text,
                Description = cardDescriptionTextBox.Text,
                Category = (CardCategory)cardCategoryComboBox.SelectedItem
            };

            cardPictureBox.Image?.Dispose();
            cardPictureBox.Image = preview.EditedImage;
        }

        private void UpdateCardDisplayedData()
        {
            if (cardsEditing == null) return;

            Console.WriteLine("Changed!");
            if (cardsEditing.Length == 1)
            {
                Card card = cardEditing;
                if (card == null) return;

                cardTitleTextBox.Text = card.Title;
                cardDescriptionTextBox.Text = card.Description;
                cardScriptComboBox.Text = card.ScriptPath;
                cardCategoryComboBox.SelectedItem = card.Category;
                cardPictureBox.Image?.Dispose();
                cardPictureBox.Image = card.EditedImage;

                updatePropertiesListBox();

                foreach (var t in cardStyleComboBox.Items.Cast<EncapsulatedCardStyleType>())
                    if (t.Type.Equals(card.Style.GetType()))
                    {
                        cardStyleComboBox.SelectedItem = t;
                        break;
                    }
            }
            else if (cardsEditing.Length > 1)
            {
                string commonTitle = cardEditing.Title;
                foreach (Card card in cardsEditing)
                {
                    if (commonTitle != card.Title)
                        commonTitle = multiValueSelectionIndicator;
                }
                cardTitleTextBox.Text = commonTitle;

                string commonDescription = cardEditing.Description;
                foreach (Card card in cardsEditing)
                {
                    if (commonDescription != card.Description)
                        commonDescription = multiValueSelectionIndicator;
                }
                cardDescriptionTextBox.Text = commonDescription;

                string commonScript = cardEditing.ScriptPath;
                foreach (Card card in cardsEditing)
                {
                    if (commonScript != card.ScriptPath)
                        commonScript = multiValueSelectionIndicator;
                }
                cardScriptComboBox.Text = commonScript;
            }
        }

        private static string GetRelativePath(string filespec, string folder)
        {
            Uri pathUri = new Uri(filespec);
            // Folders must end in a slash
            if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                folder += Path.DirectorySeparatorChar;
            }
            Uri folderUri = new Uri(folder);
            return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }

        private void UpdateScriptPaths()
        {
            cardScriptComboBox.Items.Clear();
            cardScriptComboBox.Items.AddRange(
                (from t in Directory.EnumerateFiles(Path.Combine(cardpackPath, "scripts"), "*.lua", SearchOption.AllDirectories)
                 select GetRelativePath(t, cardpackPath)).ToArray()
                );
        }

        private void cardListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            Card[] newCards = new Card[cardListBox.SelectedIndices.Count];
            cardListBox.SelectedItems.CopyTo(newCards, 0);
            cardsEditing = newCards;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection"
            dialog.ValidateNames = false;
            dialog.CheckFileExists = false;
            dialog.CheckPathExists = true;
            // Always default to Folder Selection.
            dialog.FileName = "Cardpack folder";
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            string cardsJsonPath = Path.Combine(Path.GetDirectoryName(dialog.FileName), "cards.json");
            if (!File.Exists(cardsJsonPath))
            {
                MessageBox.Show("The directory inputted is not a valid cardpack. Valid cardpacks must contain a cards.json file.", "Invalid cardpack", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<Dictionary<string, object>> json;
            using (var stream = new FileStream(cardsJsonPath, FileMode.Open))
                json = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(stream);

            data.Cards.Clear();
            foreach (Dictionary<string, object> cardJson in json)
            {
                Card parsedCard = new Card();
                if (cardJson.TryGetValue("style", out object style))
                    parsedCard.SetStyleFromString((string)style);

                parsedCard.SetDataFromDict(cardJson);
                data.Cards.Add(parsedCard);
            }

            cardpackPath = Path.GetDirectoryName(dialog.FileName);
            UpdateScriptPaths();
            RefreshListbox();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pBarText.Visible = true;
            pBar.Visible = true;
            pBar.Minimum = 0;
            pBar.Value = 0;
            pBar.Step = 1;

            if (cardpackPath == null)
            {
                OpenFileDialog dialog = new OpenFileDialog
                {
                    // Set validate names and check file exists to false otherwise windows will
                    // not let you select "Folder Selection"
                    ValidateNames = false,
                    CheckFileExists = false,
                    CheckPathExists = true,
                    // Always default to Folder Selection.
                    FileName = "Cardpack folder"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                    cardpackPath = Path.GetDirectoryName(dialog.FileName);
                else
                    return;
            }

            // TODO: Set cardpack back textures from somewhere in the application
            const string dungeonBackTextureFilename = "textures/dungeon-back.png";
            if (!File.Exists(Path.Combine(cardpackPath, dungeonBackTextureFilename)))
            {
                using (var f = new FileStream(Path.Combine(cardpackPath, dungeonBackTextureFilename), FileMode.Create))
                {
                    data.Cards[0].Style.GetBaseBackImage(CardCategory.Dungeon).Save(f, ImageFormat.Png);
                }
            }

            const string treasureBackTextureFilename = "textures/treasure-back.png";
            if (!File.Exists(Path.Combine(cardpackPath, treasureBackTextureFilename)))
            {
                using (var f = new FileStream(Path.Combine(cardpackPath, treasureBackTextureFilename), FileMode.Create))
                {
                    data.Cards[0].Style.GetBaseBackImage(CardCategory.Treasure).Save(f, ImageFormat.Png);
                }
            }

            string textureCacheDir = Path.Combine(cardpackPath, "textures/cache/");
            if (!Directory.Exists(textureCacheDir))
                Directory.CreateDirectory(textureCacheDir);

            // Delete old textures
            foreach (string path in Directory.EnumerateFiles(textureCacheDir, "*.png", SearchOption.TopDirectoryOnly))
            {
                File.Delete(path);
            }

            // Save textures
            pBarText.Text = "Saving textures...";
            pBar.Maximum = data.Cards.Count;
            Dictionary<Card, string> texturePaths = new Dictionary<Card, string>();
            uint uid = 0;
            foreach (Card card in data.Cards)
            {
                string titleFilename = new string((from c in card.Title.Replace(" ", "_") where !Path.GetInvalidFileNameChars().Contains(c) select c).ToArray()).ToLower();
                string textureFilename = textureCacheDir + (++uid).ToString() + "_" + titleFilename + ".png";
                using (var f = new FileStream(textureFilename, FileMode.CreateNew))
                {
                    using (Bitmap img = card.EditedImage)
                        img.Save(f, ImageFormat.Png);
                }

                texturePaths.Add(card, textureFilename);
                pBar.PerformStep();
            }

            pBarText.Text = "Creating cards.json...";
            pBar.Value = 0;
            List<Dictionary<string, object>> cardJsonList = new List<Dictionary<string, object>>();
            foreach (Card card in data.Cards)
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("name", card.Title);
                data.Add("description", card.Description);
                data.Add("category", card.Category == CardCategory.Dungeon ? "dungeon" : "treasure");
                data.Add("style", card.Style.GetType().Name);
                data.Add("script", card.ScriptPath);
                data.Add("front_texture", texturePaths[card]);
                data.Add("properties", card.Properties);
                pBar.PerformStep();
                cardJsonList.Add(data);
            }

            pBarText.Text = "Saving cards.json...";
            using (var f = new FileStream(Path.Combine(cardpackPath, "cards.json"), FileMode.Create))
            {
                byte[] bytes = JsonSerializer.Serialize(cardJsonList);
                f.Write(bytes, 0, bytes.Length);
            }

            pBar.Visible = false;
            pBarText.Visible = false;
        }

        private void deleteCardCtxItem_Click(object sender, EventArgs e)
        {
            if (cardListBox.SelectedItem == null)
                return;
            int offset = 0;
            foreach (int index in cardListBox.SelectedIndices)
            {
                data.Cards.RemoveAt(index - offset);
                offset++;
            }
            RefreshListbox();
        }

        private void cardTitleTextBox_KeyUp(object sender, KeyEventArgs e) => UpdateDisplayedImage();

        private void cardDescriptionTextBox_KeyUp(object sender, KeyEventArgs e) => UpdateDisplayedImage();

        private void cardStyleComboBox_SelectedIndexChanged(object sender, EventArgs e) => UpdateDisplayedImage();

        private void cardCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e) => UpdateDisplayedImage();

        private void cardListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (cardListBox.SelectedItem == null) return;

            if (e.KeyCode == Keys.Delete)
            {
                data.Cards.RemoveAt(cardListBox.SelectedIndex);

                RefreshListbox();
            }
        }

        private void cardScriptComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cardEditing.ScriptPath = (string)cardScriptComboBox.SelectedValue;
            updatePropertiesListBox();
        }

        private void updatePropertiesListBox()
        {
            if (string.IsNullOrEmpty(cardEditing.ScriptPath))
            {
                cardPropertiesLayoutPanel.Controls.Clear();
                cardPropertiesLayoutPanel.RowCount = 0;
                cardPropertiesLayoutPanel.Enabled = false;
                return;
            }

            using (StreamReader fs = File.OpenText(Path.Combine(cardpackPath, cardEditing.ScriptPath)))
            {
                cardPropertiesLayoutPanel.Controls.Clear();
                if (fs.EndOfStream) return;

                if (fs.ReadLine().TrimStart(' ') == "-- #EDITOR_PROPERTIES")
                {
                    cardPropertiesLayoutPanel.Enabled = true;
                    cardPropertiesLayoutPanel.RowStyles[0].SizeType = SizeType.AutoSize;

                    cardPropertiesLayoutPanel.RowCount = 0;
                    int i = 0;
                    while (!fs.EndOfStream)
                    {
                        string line = fs.ReadLine().Trim(' ');

                        if (line.StartsWith("-- #PROPERTY"))
                        {
                            // Read script property
                            string property_name = line.Remove(0, "-- #PROPERTY".Length).TrimStart(' ');

                            string property_value = "";
                            if (cardEditing.Properties.ContainsKey(property_name))
                                property_value = cardEditing.Properties[property_name].ToString();
                            else
                                cardEditing.Properties.Add(property_name, property_value);
                            Label label = new Label() { Text = property_name };
                            TextBox textbox = new TextBox() { Text = property_value };
                            textbox.TextChanged += (object sender, EventArgs _) => updateProperty(property_name, ((TextBox)sender).Text);
                            FlowLayoutPanel layout = new FlowLayoutPanel() { Parent = cardPropertiesLayoutPanel, FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
                            layout.Controls.Add(label);
                            layout.Controls.Add(textbox);
                            cardPropertiesLayoutPanel.RowCount++;
                            cardPropertiesLayoutPanel.SetRow(layout, i);
                        }
                        else return;
                        i++;
                    }
                }
                else
                {
                    cardPropertiesLayoutPanel.Controls.Clear();
                    cardPropertiesLayoutPanel.RowCount = 0;
                    cardPropertiesLayoutPanel.Enabled = false;
                    return;
                }
            }
        }

        private void updateProperty(string propertyName, string newData)
        {
            if(int.TryParse(newData, out int parsedIntData))
                cardEditing.Properties[propertyName] = parsedIntData;
            else if(bool.TryParse(newData, out bool parsedBoolData))
                cardEditing.Properties[propertyName] = parsedBoolData;
            else
                cardEditing.Properties[propertyName] = newData;
        }

        private void pasteFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Clipboard.ContainsText())
                return;

            foreach (string crdn in Clipboard.GetText().Split('\n'))
            {
                // Remove chars that might appear at the end of some cardnames on some places, like https://munchkin.game/products/games/munchkin/
                string cardname = crdn.TrimEnd('*', '†', ' ', '\r'); 
                if (cardname.EndsWith(")"))
                {
                    string parse_str = cardname.Remove(0, cardname.LastIndexOf('(')+1).TrimEnd(')');
                    if (int.TryParse(parse_str, out int times))
                    {
                        for(int i = 0; i < times; i++)
                            data.Cards.Add(new Card() { Title = cardname.Substring(0, cardname.LastIndexOf('(')) });
                    }
                    else
                        data.Cards.Add(new Card() { Title = cardname });
                }
                else
                    data.Cards.Add(new Card() { Title = cardname });
            }
            RefreshListbox();
        }
    }
}
