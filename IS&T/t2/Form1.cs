using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using Label = System.Windows.Forms.Label;
using TextBox = System.Windows.Forms.TextBox;

namespace t2
{
    public partial class Form1 : Form
    {
        private ListBox ListDragSource;
        private ListBox ListDragTarget1;
        private ListBox ListDragTarget2;
        private ListBox ListDragTarget3;
        private ListBox ListDragTarget4;
        private CheckBox UseCustomCursorsCheck;
        private Label DropLocationLabel;
        private Label SourceLabel;
        private Label Target1Label;
        private Label Target2Label;
        private Label Target3Label;
        private Label Target4Label;
        private TextBox NewSource;
        private Button AddSourceButton;

        private int indexOfItemUnderMouseToDrag;
        private int indexOfItemUnderMouseToDrop;

        private Rectangle dragBoxFromMouseDown;
        private Point screenOffset;

        private Cursor MyNoDropCursor;
        private Cursor MyNormalCursor;

        public Form1()
        {
            this.ListDragSource = new ListBox();
            this.ListDragTarget1 = new ListBox();
            this.ListDragTarget2 = new ListBox();
            this.ListDragTarget3 = new ListBox();
            this.ListDragTarget4 = new ListBox();
            this.UseCustomCursorsCheck = new CheckBox();
            this.DropLocationLabel = new Label();
            this.SourceLabel = new Label();
            this.Target1Label = new Label();
            this.Target2Label = new Label();
            this.Target3Label = new Label();
            this.Target4Label = new Label();
            this.NewSource = new TextBox();
            this.AddSourceButton = new Button();

            this.SuspendLayout();

            // ListDragSource
            this.ListDragSource.Location = new Point(12, 37);
            this.ListDragSource.Size = new Size(180, 129);
            this.ListDragSource.MouseDown += this.ListDragSource_MouseDown;
            this.ListDragSource.QueryContinueDrag += this.ListDragSource_QueryContinueDrag;
            this.ListDragSource.MouseUp += this.ListDragSource_MouseUp;
            this.ListDragSource.MouseMove += this.ListDragSource_MouseMove;
            this.ListDragSource.GiveFeedback += this.ListDragSource_GiveFeedback;

            // ListDragTarget1
            this.ListDragTarget1.AllowDrop = true;
            this.ListDragTarget1.Location = new Point(198, 37);
            this.ListDragTarget1.Size = new Size(180, 129);
            this.ListDragTarget1.DragOver += this.ListDragTarget1_DragOver;
            this.ListDragTarget1.DragDrop += this.ListDragTarget1_DragDrop;
            this.ListDragTarget1.DragEnter += this.ListDragTarget_DragEnter;
            this.ListDragTarget1.DragLeave += this.ListDragTarget_DragLeave;

            // ListDragTarget2
            this.ListDragTarget2.AllowDrop = true;
            this.ListDragTarget2.Location = new Point(384, 37);
            this.ListDragTarget2.Size = new Size(180, 129);
            this.ListDragTarget2.DragOver += this.ListDragTarget2_DragOver;
            this.ListDragTarget2.DragDrop += this.ListDragTarget2_DragDrop;
            this.ListDragTarget2.DragEnter += this.ListDragTarget_DragEnter;
            this.ListDragTarget2.DragLeave += this.ListDragTarget_DragLeave;

            // ListDragTarget3
            this.ListDragTarget3.AllowDrop = true;
            this.ListDragTarget3.Location = new Point(198, 197);
            this.ListDragTarget3.Size = new Size(180, 129);
            this.ListDragTarget3.DragOver += this.ListDragTarget3_DragOver;
            this.ListDragTarget3.DragDrop += this.ListDragTarget3_DragDrop;
            this.ListDragTarget3.DragEnter += this.ListDragTarget_DragEnter;
            this.ListDragTarget3.DragLeave += this.ListDragTarget_DragLeave;

            // ListDragTarget4
            this.ListDragTarget4.AllowDrop = true;
            this.ListDragTarget4.Location = new Point(384, 197);
            this.ListDragTarget4.Size = new Size(180, 129);
            this.ListDragTarget4.DragOver += this.ListDragTarget4_DragOver;
            this.ListDragTarget4.DragDrop += this.ListDragTarget4_DragDrop;
            this.ListDragTarget4.DragEnter += this.ListDragTarget_DragEnter;
            this.ListDragTarget4.DragLeave += this.ListDragTarget_DragLeave;

            // UseCustomCursorsCheck
            this.UseCustomCursorsCheck.Location = new Point(10, 358);
            this.UseCustomCursorsCheck.Size = new Size(199, 24);
            this.UseCustomCursorsCheck.Text = "Use Custom Cursors";

            // DropLocationLabel
            this.DropLocationLabel.Location = new Point(212, 358);
            this.DropLocationLabel.Size = new Size(199, 24);
            this.DropLocationLabel.Text = "None";

            // SourceLabel
            SourceLabel.Location = new Point(12, 9);
            SourceLabel.Size = new Size(63, 25);
            SourceLabel.Text = "Факты";

            // Target1Label
            Target1Label.Location = new Point(198, 9);
            Target1Label.Size = new Size(159, 25);
            Target1Label.Text = "Сильные стороны";

            // Target2Label
            Target2Label.Location = new Point(384, 9);
            Target2Label.Size = new Size(149, 25);
            Target2Label.Text = "Слабые стороны";

            // Target3Label
            Target3Label.Location = new Point(198, 169);
            Target3Label.Size = new Size(124, 25);
            Target3Label.Text = "Возможности";

            // Target4Label
            Target4Label.Location = new Point(384, 169);
            Target4Label.Size = new Size(72, 25);
            Target4Label.Text = "Угрозы";

            // NewSource
            NewSource.Location = new Point(12, 197);
            NewSource.Size = new Size(180, 31);

            // AddSource
            AddSourceButton.Location = new Point(12, 234);
            AddSourceButton.Size = new Size(180, 40);
            AddSourceButton.Text = "Добавить факт";
            AddSourceButton.UseVisualStyleBackColor = true;
            AddSourceButton.Click += AddSourceButton_Click;

            // Form1
            this.ClientSize = new Size(598, 394);
            this.Controls.AddRange(new Control[] {
                this.ListDragSource,
                this.ListDragTarget1,
                this.ListDragTarget2,
                this.ListDragTarget3,
                this.ListDragTarget4,
                this.SourceLabel,
                this.Target1Label,
                this.Target2Label,
                this.Target3Label,
                this.Target4Label,
                this.UseCustomCursorsCheck,
                this.DropLocationLabel,
                this.NewSource,
                this.AddSourceButton});
            this.Text = "drag-and-drop SWOT";

            this.ResumeLayout(false);
        }

        private void AddSourceButton_Click(object sender, EventArgs e)
        {
            if (NewSource.Text != "")
            {
                ListDragSource.Items.Add(NewSource.Text);
                NewSource.Text = string.Empty;
            }
        }

        private void ListDragSource_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            indexOfItemUnderMouseToDrag = ListDragSource.IndexFromPoint(e.X, e.Y);

            if (indexOfItemUnderMouseToDrag != ListBox.NoMatches)
            {
                // Remember the point where the mouse down occurred. The DragSize indicates
                // the size that the mouse can move before a drag event should be started.
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(
                    new Point(e.X - (dragSize.Width / 2),
                              e.Y - (dragSize.Height / 2)),
                    dragSize);
            }
            else
            {
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
            }
        }

        private void ListDragSource_MouseUp(object sender, MouseEventArgs e)
        {
            // Reset the drag rectangle when the mouse button is raised.
            dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void ListDragSource_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Create custom cursors for the drag-and-drop operation.
                    try
                    {
                        MyNormalCursor = new Cursor("3dwarro.cur");
                        MyNoDropCursor = new Cursor("3dwno.cur");
                    }
                    catch
                    {
                        // An error occurred while attempting to load the cursors, so use
                        // standard cursors.
                        UseCustomCursorsCheck.Checked = false;
                    }
                    finally
                    {
                        // The screenOffset is used to account for any desktop bands 
                        // that may be at the top or left side of the screen when 
                        // determining when to cancel the drag drop operation.
                        screenOffset = SystemInformation.WorkingArea.Location;

                        // Proceed with the drag-and-drop, passing in the list item.
                        DragDropEffects dropEffect = ListDragSource.DoDragDrop(ListDragSource.Items[indexOfItemUnderMouseToDrag], DragDropEffects.All | DragDropEffects.Link);

                        // If the drag operation was a move then remove the item.
                        if (dropEffect == DragDropEffects.Move)
                        {
                            ListDragSource.Items.RemoveAt(indexOfItemUnderMouseToDrag);

                            // Selects the previous item in the list as long as the list has an item.
                            if (indexOfItemUnderMouseToDrag > 0)
                                ListDragSource.SelectedIndex = indexOfItemUnderMouseToDrag - 1;

                            else if (ListDragSource.Items.Count > 0)
                                // Selects the first item.
                                ListDragSource.SelectedIndex = 0;
                        }

                        // Dispose of the cursors since they are no longer needed.
                        if (MyNormalCursor != null)
                            MyNormalCursor.Dispose();

                        if (MyNoDropCursor != null)
                            MyNoDropCursor.Dispose();
                    }
                }
            }
        }
        private void ListDragSource_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            // Use custom cursors if the check box is checked.
            if (UseCustomCursorsCheck.Checked)
            {
                // Sets the custom cursor based upon the effect.
                e.UseDefaultCursors = false;
                if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
                    Cursor.Current = MyNormalCursor;
                else
                    Cursor.Current = MyNoDropCursor;
            }
        }
        private void ListDragTarget1_DragOver(object sender, DragEventArgs e)
        {
            // Determine whether string data exists in the drop data. If not, then
            // the drop effect reflects that the drop cannot occur.
            if (!e.Data.GetDataPresent(typeof(System.String)))
            {
                e.Effect = DragDropEffects.None;
                DropLocationLabel.Text = "None - no string data.";
                return;
            }

            // Set the effect based upon the KeyState.
            if ((e.KeyState & (8 + 32)) == (8 + 32) &&
                (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link)
            {
                // KeyState 8 + 32 = CTRL + ALT

                // Link drag-and-drop effect.
                e.Effect = DragDropEffects.Link;
            }
            else if ((e.KeyState & 32) == 32 &&
                (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link)
            {
                // ALT KeyState for link.
                e.Effect = DragDropEffects.Link;
            }
            else if ((e.KeyState & 4) == 4 &&
                (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                // SHIFT KeyState for move.
                e.Effect = DragDropEffects.Move;
            }
            else if ((e.KeyState & 8) == 8 &&
                (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                // CTRL KeyState for copy.
                e.Effect = DragDropEffects.Copy;
            }
            else if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                // By default, the drop action should be move, if allowed.
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

            // Get the index of the item the mouse is below. 

            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.

            indexOfItemUnderMouseToDrop =
                ListDragTarget1.IndexFromPoint(ListDragTarget1.PointToClient(new Point(e.X, e.Y)));

            // Updates the label text.
            if (indexOfItemUnderMouseToDrop != ListBox.NoMatches)
            {
                DropLocationLabel.Text = "Drops before item #" + (indexOfItemUnderMouseToDrop + 1);
            }
            else
            {
                DropLocationLabel.Text = "Drops at the end.";
            }
        }
        private void ListDragTarget1_DragDrop(object sender, DragEventArgs e)
        {
            // Ensure that the list item index is contained in the data.
            if (e.Data.GetDataPresent(typeof(System.String)))
            {
                Object item = e.Data.GetData(typeof(System.String));

                // Perform drag-and-drop, depending upon the effect.
                if (e.Effect == DragDropEffects.Copy ||
                    e.Effect == DragDropEffects.Move)
                {
                    // Insert the item.
                    if (indexOfItemUnderMouseToDrop != ListBox.NoMatches)
                        ListDragTarget1.Items.Insert(indexOfItemUnderMouseToDrop, item);
                    else
                        ListDragTarget1.Items.Add(item);
                }
            }
            // Reset the label text.
            DropLocationLabel.Text = "None";
        }
        private void ListDragTarget2_DragOver(object sender, DragEventArgs e)
        {
            // Determine whether string data exists in the drop data. If not, then
            // the drop effect reflects that the drop cannot occur.
            if (!e.Data.GetDataPresent(typeof(System.String)))
            {
                e.Effect = DragDropEffects.None;
                DropLocationLabel.Text = "None - no string data.";
                return;
            }

            // Set the effect based upon the KeyState.
            if ((e.KeyState & (8 + 32)) == (8 + 32) &&
                (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link)
            {
                // KeyState 8 + 32 = CTRL + ALT

                // Link drag-and-drop effect.
                e.Effect = DragDropEffects.Link;
            }
            else if ((e.KeyState & 32) == 32 &&
                (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link)
            {
                // ALT KeyState for link.
                e.Effect = DragDropEffects.Link;
            }
            else if ((e.KeyState & 4) == 4 &&
                (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                // SHIFT KeyState for move.
                e.Effect = DragDropEffects.Move;
            }
            else if ((e.KeyState & 8) == 8 &&
                (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                // CTRL KeyState for copy.
                e.Effect = DragDropEffects.Copy;
            }
            else if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                // By default, the drop action should be move, if allowed.
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

            // Get the index of the item the mouse is below. 

            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.

            indexOfItemUnderMouseToDrop =
                ListDragTarget2.IndexFromPoint(ListDragTarget2.PointToClient(new Point(e.X, e.Y)));

            // Updates the label text.
            if (indexOfItemUnderMouseToDrop != ListBox.NoMatches)
            {
                DropLocationLabel.Text = "Drops before item #" + (indexOfItemUnderMouseToDrop + 1);
            }
            else
            {
                DropLocationLabel.Text = "Drops at the end.";
            }
        }
        private void ListDragTarget2_DragDrop(object sender, DragEventArgs e)
        {
            // Ensure that the list item index is contained in the data.
            if (e.Data.GetDataPresent(typeof(System.String)))
            {
                Object item = e.Data.GetData(typeof(System.String));

                // Perform drag-and-drop, depending upon the effect.
                if (e.Effect == DragDropEffects.Copy ||
                    e.Effect == DragDropEffects.Move)
                {
                    // Insert the item.
                    if (indexOfItemUnderMouseToDrop != ListBox.NoMatches)
                        ListDragTarget2.Items.Insert(indexOfItemUnderMouseToDrop, item);
                    else
                        ListDragTarget2.Items.Add(item);
                }
            }
            // Reset the label text.
            DropLocationLabel.Text = "None";
        }
        private void ListDragTarget3_DragOver(object sender, DragEventArgs e)
        {
            // Determine whether string data exists in the drop data. If not, then
            // the drop effect reflects that the drop cannot occur.
            if (!e.Data.GetDataPresent(typeof(System.String)))
            {
                e.Effect = DragDropEffects.None;
                DropLocationLabel.Text = "None - no string data.";
                return;
            }

            // Set the effect based upon the KeyState.
            if ((e.KeyState & (8 + 32)) == (8 + 32) &&
                (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link)
            {
                // KeyState 8 + 32 = CTRL + ALT

                // Link drag-and-drop effect.
                e.Effect = DragDropEffects.Link;
            }
            else if ((e.KeyState & 32) == 32 &&
                (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link)
            {
                // ALT KeyState for link.
                e.Effect = DragDropEffects.Link;
            }
            else if ((e.KeyState & 4) == 4 &&
                (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                // SHIFT KeyState for move.
                e.Effect = DragDropEffects.Move;
            }
            else if ((e.KeyState & 8) == 8 &&
                (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                // CTRL KeyState for copy.
                e.Effect = DragDropEffects.Copy;
            }
            else if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                // By default, the drop action should be move, if allowed.
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

            // Get the index of the item the mouse is below. 

            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.

            indexOfItemUnderMouseToDrop =
                ListDragTarget3.IndexFromPoint(ListDragTarget3.PointToClient(new Point(e.X, e.Y)));

            // Updates the label text.
            if (indexOfItemUnderMouseToDrop != ListBox.NoMatches)
            {
                DropLocationLabel.Text = "Drops before item #" + (indexOfItemUnderMouseToDrop + 1);
            }
            else
            {
                DropLocationLabel.Text = "Drops at the end.";
            }
        }
        private void ListDragTarget3_DragDrop(object sender, DragEventArgs e)
        {
            // Ensure that the list item index is contained in the data.
            if (e.Data.GetDataPresent(typeof(System.String)))
            {
                Object item = e.Data.GetData(typeof(System.String));

                // Perform drag-and-drop, depending upon the effect.
                if (e.Effect == DragDropEffects.Copy ||
                    e.Effect == DragDropEffects.Move)
                {
                    // Insert the item.
                    if (indexOfItemUnderMouseToDrop != ListBox.NoMatches)
                        ListDragTarget3.Items.Insert(indexOfItemUnderMouseToDrop, item);
                    else
                        ListDragTarget3.Items.Add(item);
                }
            }
            // Reset the label text.
            DropLocationLabel.Text = "None";
        }
        private void ListDragTarget4_DragOver(object sender, DragEventArgs e)
        {
            // Determine whether string data exists in the drop data. If not, then
            // the drop effect reflects that the drop cannot occur.
            if (!e.Data.GetDataPresent(typeof(System.String)))
            {
                e.Effect = DragDropEffects.None;
                DropLocationLabel.Text = "None - no string data.";
                return;
            }

            // Set the effect based upon the KeyState.
            if ((e.KeyState & (8 + 32)) == (8 + 32) &&
                (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link)
            {
                // KeyState 8 + 32 = CTRL + ALT

                // Link drag-and-drop effect.
                e.Effect = DragDropEffects.Link;
            }
            else if ((e.KeyState & 32) == 32 &&
                (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link)
            {
                // ALT KeyState for link.
                e.Effect = DragDropEffects.Link;
            }
            else if ((e.KeyState & 4) == 4 &&
                (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                // SHIFT KeyState for move.
                e.Effect = DragDropEffects.Move;
            }
            else if ((e.KeyState & 8) == 8 &&
                (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                // CTRL KeyState for copy.
                e.Effect = DragDropEffects.Copy;
            }
            else if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                // By default, the drop action should be move, if allowed.
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

            // Get the index of the item the mouse is below. 

            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.

            indexOfItemUnderMouseToDrop =
                ListDragTarget4.IndexFromPoint(ListDragTarget4.PointToClient(new Point(e.X, e.Y)));

            // Updates the label text.
            if (indexOfItemUnderMouseToDrop != ListBox.NoMatches)
            {
                DropLocationLabel.Text = "Drops before item #" + (indexOfItemUnderMouseToDrop + 1);
            }
            else
            {
                DropLocationLabel.Text = "Drops at the end.";
            }
        }
        private void ListDragTarget4_DragDrop(object sender, DragEventArgs e)
        {
            // Ensure that the list item index is contained in the data.
            if (e.Data.GetDataPresent(typeof(System.String)))
            {
                Object item = e.Data.GetData(typeof(System.String));

                // Perform drag-and-drop, depending upon the effect.
                if (e.Effect == DragDropEffects.Copy ||
                    e.Effect == DragDropEffects.Move)
                {
                    // Insert the item.
                    if (indexOfItemUnderMouseToDrop != ListBox.NoMatches)
                        ListDragTarget4.Items.Insert(indexOfItemUnderMouseToDrop, item);
                    else
                        ListDragTarget4.Items.Add(item);
                }
            }
            // Reset the label text.
            DropLocationLabel.Text = "None";
        }
        private void ListDragSource_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            // Cancel the drag if the mouse moves off the form.
            ListBox lb = sender as ListBox;

            if (lb != null)
            {
                Form f = lb.FindForm();

                // Cancel the drag if the mouse moves off the form. The screenOffset
                // takes into account any desktop bands that may be at the top or left
                // side of the screen.
                if (((Control.MousePosition.X - screenOffset.X) < f.DesktopBounds.Left) ||
                    ((Control.MousePosition.X - screenOffset.X) > f.DesktopBounds.Right) ||
                    ((Control.MousePosition.Y - screenOffset.Y) < f.DesktopBounds.Top) ||
                    ((Control.MousePosition.Y - screenOffset.Y) > f.DesktopBounds.Bottom))
                {
                    e.Action = DragAction.Cancel;
                }
            }
        }
        private void ListDragTarget_DragEnter(object sender, DragEventArgs e)
        {
            // Reset the label text.
            DropLocationLabel.Text = "None";
        }
        private void ListDragTarget_DragLeave(object sender, EventArgs e)
        {
            // Reset the label text.
            DropLocationLabel.Text = "None";
        }
    }
}