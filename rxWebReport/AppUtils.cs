using System.Web.UI;

namespace rxWebReport
{
    static class AppUtils
    {
        public static Control FindControlRecursive(Control control, string id)
        {
            if (control == null)
                return null /* TODO Change to default(_) if this is not a reference type */;
            // try to find the control at the current level
            Control ctrl = control.FindControl(id);

            if (ctrl == null)
            {
                // search the children
                foreach (Control child in control.Controls)
                {
                    ctrl = FindControlRecursive(child, id);

                    if (ctrl != null)
                        break;
                }
            }
            return ctrl;
        }
    }
}
