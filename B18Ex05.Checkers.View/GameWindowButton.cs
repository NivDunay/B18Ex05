using System.Drawing;
using System.Windows.Forms;

namespace B18Ex05.Checkers.View
{
	public class GameWindowButton : Button
	{
		private readonly Point r_Location;

		public GameWindowButton(Point i_Location)
		{
			Name = i_Location.ToString();
			Text = string.Empty;
			r_Location = i_Location;
			Height = Constants.k_ButtonHeight;
			Width = Constants.k_ButtonWidth;
			BackColor = Color.White;
			Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
		}

		public Point ButtonLocation
		{
			get { return r_Location; }
		}
	}
}