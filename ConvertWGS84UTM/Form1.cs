using System;
using System.Windows.Forms;

namespace ConvertWGS84UTM
{
    public partial class Form1 : Form
    {
        private int zone = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonWGS84toUTM_Click(object sender, EventArgs e)
        {
            string wgsLat = TextBoxWGSLat.Text;
            string wgsLon = TextBoxWGSLon.Text;

            if (wgsLat.Length > 0 && wgsLon.Length > 0)
            {
                if (!double.TryParse(wgsLat, out double dWgsLat))
                {
                    return;
                }
                if (!double.TryParse(wgsLon, out double dWgsLon))
                {
                    return;
                }

                if (WGS84UTM.LatLngToUtm(dWgsLat, dWgsLon, out double utmLat, out double utmLon, out int p1utm_zone))
                {
                    TextBoxUTMLat.Text = $"{utmLat:0.##}";
                    TextBoxUTMLon.Text = $"{utmLon:0.##}";
                    zone = p1utm_zone;
                }
            }
        }

        private void ButtonUTMtoWGS84_Click(object sender, EventArgs e)
        {
            if (zone > 0)
            {
                string utmLat = TextBoxUTMLat.Text;
                string utmLon = TextBoxUTMLon.Text;

                if (utmLat.Length > 0 && utmLon.Length > 0)
                {
                    if (!double.TryParse(utmLat, out double dUtmLat))
                    {
                        return;
                    }
                    if (!double.TryParse(utmLon, out double dUtmLon))
                    {
                        return;
                    }

                    WGS84UTM.ConvertUtmToGeo(dUtmLat, dUtmLon, zone, out double wgsLat, out double wgsLon);

                    TextBoxWGSLat2.Text = $"{wgsLat:#.#######}";
                    TextBoxWGSLon2.Text = $"{wgsLon:#.#######}";
                }
            }
        }
    }
}