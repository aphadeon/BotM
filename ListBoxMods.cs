using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotM
{
    public class ListBoxMods : ListBox
    {
        public ListBoxMods()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 66;
        }

        public void ListHack()
        {
            RefreshItems();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            const TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;

            if (e.Index >= 0)
            {
                if(Items.Count == 0)
                {
                    return;
                }
                e.DrawBackground();
                ModListing m = (ModListing)Items[e.Index];
                if (m.HasIcon)
                {
                    e.Graphics.DrawImage(m.Icon, 2, e.Bounds.Y + 2, 64, 64);
                }
                else
                {
                    e.Graphics.DrawRectangle(System.Drawing.Pens.Red, 2, e.Bounds.Y + 2, 64, 64); // Simulate an icon.
                }
                var textRect = e.Bounds;
                textRect.X += 70;
                textRect.Width -= 20;
                string itemText = DesignMode ? "ListBoxMods" : Items[e.Index].ToString();
                TextRenderer.DrawText(e.Graphics, itemText, e.Font, textRect, e.ForeColor, flags);
                e.DrawFocusRectangle();
            }
        }
    }
}