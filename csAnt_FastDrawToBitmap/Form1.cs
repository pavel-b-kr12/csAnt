using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Collections;
using System.IO;
using System.Globalization;
using Timer = System.Windows.Forms.Timer;

namespace csAnt_FastDrawToBitmap
{
    public partial class Form1 : Form
    {
        Timer tm = new Timer();

        Bitmap image;
        Bitmap imageColorized;
        byte bitsPerPixelDiv8;
        const int fieldSize = 1024;

        public static long[][] _jagged;

        Ant ant = new Ant(fieldSize - 1, fieldSize - 1, fieldSize / 2, fieldSize / 2, 0);
        public Form1()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();


            image =             new Bitmap(fieldSize, fieldSize, PixelFormat.Format32bppPArgb);//Format32bppPArgb probably is fastest
            imageColorized =    new Bitmap(fieldSize, fieldSize, PixelFormat.Format32bppPArgb);
            pictureBox1.Image = image;
            //pictureBox2.Image = imageColorized;

            bitsPerPixelDiv8 = (byte)(GetBitsPerPixel(image)/8);

            comboBox_colorizeType.DataSource = Enum.GetValues(typeof(ColorizeType));
            comboBox_colorizeType.SelectedItem = ColorizeType.drawState;
            comboBox_colorizeType.SelectedValueChanged += new System.EventHandler(this.comboBox_colorizeType_SelectionChange);

            listBox_ColorizeSkipBGType.DataSource = Enum.GetValues(typeof(ColorizeSkipBGType));

            slider_colorizeRange.Value = 18;


            _jagged = new long[fieldSize][];
            for (int i = 0; i < fieldSize; i++)
                _jagged[i] = new long[fieldSize];

            clearALl();

            tm.Tick += new EventHandler(RedrawImg);
            tm.Interval = 2;
            tm.Start();


        }
        public static byte GetBitsPerPixel(Bitmap b)
        {
            switch (b.PixelFormat)
            {
                case PixelFormat.Format1bppIndexed:
                    return 1;
                case PixelFormat.Format4bppIndexed:
                    return 4;
                case PixelFormat.Format8bppIndexed:
                    return 8;
                case PixelFormat.Format16bppGrayScale:
                case PixelFormat.Format16bppRgb555:
                case PixelFormat.Format16bppRgb565:
                case PixelFormat.Format16bppArgb1555:
                    return 16;
                case PixelFormat.Format24bppRgb:
                    return 24;
                case PixelFormat.Format32bppRgb:
                case PixelFormat.Format32bppArgb:
                case PixelFormat.Format32bppPArgb:
                    return 32;
                case PixelFormat.Format48bppRgb:
                    return 48;
                case PixelFormat.Format64bppArgb:
                case PixelFormat.Format64bppPArgb:
                    return 64;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }



        Stopwatch sw = new Stopwatch();
        Stopwatch swWalk = new Stopwatch();
        long draw_dt = 10, walk_dt=20;
        int speed = 1000;
        long ii = 0; //ant step counter
        int iFrame = 0;
        bool bShow_imageColorized = false;
        private unsafe void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bData">get field or if(bDrawColorizationToField_) get colorization image</param>
        /// <param name="scan0"></param>
        /// <param name="bData_field">if(bDrawColorizationToField_) get field</param>
        /// <param name="scan0_field"></param>
        private unsafe void fill_histH(BitmapData bData, byte* scan0, BitmapData bData_field, byte* scan0_field)
        {
            ///*
            Parallel.For(0, bData.Height, i => {
                for (int j = 0; j < bData.Width; ++j)
                {
                    byte* data = scan0 + i * bData.Stride + j * bitsPerPixelDiv8;

                    byte r, g, b;

                    switch (colorizeSkipBGType)
                    {
                        case ColorizeSkipBGType.none:
                            break;
                        case ColorizeSkipBGType.skipBG:
                            if (_jagged[i][j] == 0) continue;
                            break;
                        case ColorizeSkipBGType.skip0:
                            if (bData_field == null)
                            {
                                if (data[0] == 0) continue;
                            }
                            else
                            {
                                byte* data_field = scan0_field + i * bData_field.Stride + j * bitsPerPixelDiv8;
                                if (data_field[0] == 0) continue;
                            }
                            break;
                        case ColorizeSkipBGType.skipOld:
                            if (_jagged[i][j] < ii - 11000) //sett //11000 @ 50k speed , +mirrorWall
                            {
                                data[0] = 0;
                                data[1] = 0; //sett
                                data[2] = 0; //sett

                                continue;
                            }
                            else
                            {
                                //_jagged[i][j] += 500; //sett
                                _jagged[i][j]++;

                            }
                            break;
                        default:
                            break;
                    }

                    hsvrgb.HToRgb(_jagged[i][j] + iFrame * 100, out r, out g, out b); //! speed settings
                    data[0] = r;
                    data[1] = g;
                    data[2] = b;

                }
            });
            //*/
           /*  //single thread
            for (int i = 0; i < bData.Height; ++i)
            {
                for (int j = 0; j < bData.Width; ++j)
                {
                    byte* data = scan0 + i * bData.Stride + j * bitsPerPixelDiv8;

                    byte r, g, b;

                    switch (colorizeSkipBGType)
                    {
                        case ColorizeSkipBGType.none:
                            break;
                        case ColorizeSkipBGType.skipBG:
                            if (_jagged[i][j] == 0) continue;
                            break;
                        case ColorizeSkipBGType.skip0:
                            if (bData_field == null)
                            {
                                if (data[0] == 0) continue;
                            }
                            else
                            {
                                byte* data_field = scan0_field + i * bData_field.Stride + j * bitsPerPixelDiv8;
                                if (data_field[0] == 0) continue;
                            }
                            break;
                        case ColorizeSkipBGType.skipOld:
                            if (_jagged[i][j] < ii - 11000) //sett //11000 @ 50k speed , +mirrorWall
                            {
                                data[0] = 0;
                                data[1] = 0; //sett
                                data[2] = 0; //sett

                                continue;
                            }
                            else
                            {
                                //_jagged[i][j] += 500; //sett
                                _jagged[i][j]++;

                            }
                            break;
                        default:
                            break;
                    }

                        hsvrgb.HToRgb(_jagged[i][j] + iFrame * 100, out r, out g, out b); //! speed settings
                        data[0] = r;
                        data[1] = g;
                        data[2] = b;

                }
            }
            */
        }
        private unsafe void fill_histHmodAbs(BitmapData bData, byte* scan0)
        {
            for (int i = 0; i < bData.Height; ++i)
            {
                for (int j = 0; j < bData.Width; ++j)
                {
                    byte* data = scan0 + i * bData.Stride + j * bitsPerPixelDiv8;

                    //62ms
                    var c = _jagged[i][j] * 0.01 + iFrame;
                    data[0] = (byte)(Math.Abs(c % 512 - 256));
                    data[1] = (byte)(Math.Abs((c + 80) % 512 - 256));
                    data[2] = (byte)(Math.Abs((c + 160) % 512 - 256));
                }
            }
        }

        /// <summary>
        /// fastest (58ms @1Mp)
        /// </summary>
        private unsafe void fill_histHmod(BitmapData bData, byte* scan0)
        {
            for (int i = 0; i < bData.Height; ++i)
            {
                for (int j = 0; j < bData.Width; ++j)
                {
                    byte* data = scan0 + i * bData.Stride + j * bitsPerPixelDiv8;


                    var c = _jagged[i][j] * 0.01 + iFrame;
                    data[0] = (byte)(c % 256);
                    data[1] = (byte)((c + 80) % 256);
                    data[2] = (byte)((c + 160) % 256);
                }
            }
        }

        private unsafe void fill_clear(BitmapData bData, byte* scan0)
        {
            for (int i = 0; i < bData.Height; ++i)
            {
                for (int j = 0; j < bData.Width; ++j)
                {
                    byte* data = scan0 + i * bData.Stride + j * bitsPerPixelDiv8;
                    data[0] = 0;
                    data[1] = 0;
                    data[2] = 0;
                    data[3] = 255; //a
                }
            }
        }

        private unsafe byte* getColorFromArr(int x, int y, BitmapData bData, byte* scan0)
        {
            return scan0 + x * bData.Stride + y * bitsPerPixelDiv8;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RedrawImg();
        }
        public unsafe void RedrawImg()
        {
  
            pictureBox1.Invalidate();
            //pictureBox2.Invalidate();
        }

        bool bctrl_old = false;
        public unsafe void RedrawImg(object sender, EventArgs e)  //or e.Graphics.DrawImage(bitmap, 60, 10);
        {
            if (IsControlDown() != bctrl_old )
            {
                bctrl_old = !bctrl_old;
                bShow_imageColorized = !bShow_imageColorized;
                checkBox_show_imageColorized.Checked = bShow_imageColorized; //! invoke //this run checkBox_show_imageColorized_CheckedChanged
            }

            bool bDrawColorizationToField_ = bDrawColorizationToField; //? is this help to thread safe, so not changed inside nethod
            sw.Restart();
            

            //Bitmap image = (Bitmap)pictureBox1.Image;
            BitmapData bData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, image.PixelFormat);
            byte* scan0 = (byte*)bData.Scan0.ToPointer();

            swWalk.Restart();
            //!! re wall type
            if (bMirror)
                for (int i = 0; i < speed; i++)
                {
                    byte* cc = getColorFromArr(ant.x, ant.y, bData, scan0);
                    cc[0] = ant.runWallsReversable(cc[0]);
                    _jagged[ant.x][ant.y] = ii; ii++;

                    if (colorizeType == ColorizeType.fill_histH_eachStep_skipBG)
                    {
                        //slow  fill_histH(bData, scan0);
                        byte r, g, b;
                        hsvrgb.HToRgb(_jagged[ant.x][ant.y] + iFrame * 100, out r, out g, out b); //! speed settings
                        cc[0] = r;
                        cc[1] = g;
                        cc[2] = b;
                    }
                }
            else
                for (int i = 0; i < speed; i++)
                {
                    byte* cc = getColorFromArr(ant.x, ant.y, bData, scan0);
                    cc[0] = ant.run(cc[0]);
                    _jagged[ant.x][ant.y] = ii; ii++;

                    if (colorizeType == ColorizeType.fill_histH_eachStep_skipBG)
                    {
                        //slow  fill_histH(bData, scan0);
                        byte r, g, b;
                        hsvrgb.HToRgb(_jagged[ant.x][ant.y] + iFrame * 100, out r, out g, out b); //! speed settings
                        cc[0] = r;
                        cc[1] = g;
                        cc[2] = b;
                    }
                }
            swWalk.Stop();
            walk_dt = (swWalk.ElapsedMilliseconds + walk_dt) / 2;
            label_dt_walk.Text = walk_dt.ToString();
            //label_step_ii.Text = ii.ToString();


            if (bDrawColorizationToField_)
            {
                switch (colorizeType) //colorization function is time critical, can eat 70%
                {
                    case ColorizeType.drawState: break;
                    case ColorizeType.fill_histH: fill_histH(bData, scan0, null, null); break;
                    case ColorizeType.fill_histHabs: fill_histHmodAbs(bData, scan0); break;
                    case ColorizeType.fill_histHmod: fill_histHmod(bData, scan0); break;
                }
            }
            else
            {
                BitmapData bDataC = imageColorized.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, image.PixelFormat);
                byte* scan0C = (byte*)bDataC.Scan0.ToPointer();
                switch (colorizeType) //colorization function is time critical, can eat 70%
                {
                    case ColorizeType.drawState: break;
                    case ColorizeType.fill_histH: fill_histH(bDataC, scan0C, bData, scan0); break;
                    case ColorizeType.fill_histHabs: fill_histHmodAbs(bDataC, scan0C); break;
                    case ColorizeType.fill_histHmod: fill_histHmod(bDataC, scan0C); break;
                }
                imageColorized.UnlockBits(bDataC);
            }

            image.UnlockBits(bData);

            sw.Stop();

            draw_dt = (sw.ElapsedMilliseconds- walk_dt + draw_dt) / 2;
            button1.Text = draw_dt.ToString();

            iFrame++;

            //^^ double buffering
            //using (Graphics G = Graphics.FromImage(first)) { G.DrawImage(current, 0, 0); }
            //using (Graphics G = Graphics.FromImage(image)) { G.DrawImage(image, 0, 0); } 
            //@ https://stackoverflow.com/questions/32806872/c-sharp-bitmap-region-is-already-locked
            //pictureBox1.Refresh();

            pictureBox1.Invalidate();
            //pictureBox2.Invalidate();
        }

        private unsafe void btn_fillField_clear_Click(object sender, EventArgs e)
        {
            //colorizeType_old = colorizeType;
            //colorizeType = ColorizeType.fill_clear;

            clearALl();

            //colorizeType = colorizeType_old;
        }

        private unsafe void clearALl()
        {
            ant.x = image.Width / 2;
            ant.y = image.Height / 2;

            clearBitmap(image);
            clearBitmap(imageColorized);

            for (int i = 0; i < image.Height; ++i)
            {
                for (int j = 0; j < image.Width; ++j)
                {
                    _jagged[i][j] = 0; //!! test h w
                }
            }
        }

        private unsafe void clearBitmap(Bitmap image)
        {
            BitmapData bData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, image.PixelFormat);
            byte* scan0 = (byte*)bData.Scan0.ToPointer();
            fill_clear(bData, scan0);
            image.UnlockBits(bData);
        }

        bool bMirror = false;
        bool bDrawHist = false;
        ColorizeType colorizeType = ColorizeType.drawState;
        ColorizeType colorizeType_old = ColorizeType.drawState;
        ColorizeSkipBGType colorizeSkipBGType = ColorizeSkipBGType.none;

        private void checkBox_mirrorWall_CheckStateChanged(object sender, EventArgs e)
        {
            bMirror = checkBox_mirrorWall.Checked;
        }

        private void btn_speed_Click(object sender, EventArgs e)
        {
            switch (speed)
            {
                //case 10:  speed = 100; break;
                case 100: speed = 1000; break;
                case 1000: speed = 10000; break;
                case 10000: speed = 50000; break;
                case 50000: speed = 1000000; break;
                case 1000000: speed = 10000000; break;
                default: speed = 100; break;
            }
            btn_speed.Text = string_helper.numStr(speed);
        }
        private void btn_speed_sub_Click(object sender, EventArgs e)
        {
            switch (speed)
            {
                case 100: speed = 20; break;
                case 1000: speed = 100; break;
                case 50000: speed = 1000; break;
                case 1000000: speed = 50000; break;
                default: speed = 1000000; break;
            }
            btn_speed.Text = string_helper.numStr(speed);
        }

        private void checkBox_bDrawHist_CheckStateChanged(object sender, EventArgs e)
        {
            bDrawHist = checkBox_bDrawColorizationToField.Checked;
        }


        private void comboBox_colorizeType_SelectionChange(object sender, EventArgs e)
        {
            colorizeType_old = colorizeType;
            colorizeType = (ColorizeType)comboBox_colorizeType.SelectedItem;

            switch (colorizeType)
            {
                case ColorizeType.fill_histH:
                    hsvrgb.H_mod = 360 * 20;
                    break;
                case ColorizeType.fill_histH_eachStep_skipBG:
                    colorizeSkipBGType = ColorizeSkipBGType.skipBG;
                    hsvrgb.H_mod = 360 * 20;
                    break;
                case ColorizeType.fill_histHabs:
                    hsvrgb.H_mod = 360 * 100;
                    break;
                case ColorizeType.fill_histHmod:
                    hsvrgb.H_mod = 360 * 100;
                    break;
                case ColorizeType.fill_clear:
                    break;
                case ColorizeType.drawState:
                    break;
                default:
                    break;
            }

            //or Status status; Enum.TryParse<Status>(cbStatus.SelectedValue.ToString(), out status);
        }

        bool bDrawColorizationToField = false;
        private void checkBox_bDrawColorizationToField_CheckedChanged(object sender, EventArgs e)
        {
            bDrawColorizationToField = checkBox_bDrawColorizationToField.Checked;

            //pictureBox1.Image = bDrawColorizationToField? image : imageColorized;
        }

        private void listBox_ColorizeSkipBGType_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorizeSkipBGType = (ColorizeSkipBGType)listBox_ColorizeSkipBGType.SelectedItem;
        }

        public static bool IsControlDown()
        {
            return (Control.ModifierKeys & Keys.Control) != 0;
            //using System.Windows.Input;  return Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
        }

        private void btn_show_imageColorized_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_show_imageColorized_CheckedChanged(object sender, EventArgs e)
        {
            bShow_imageColorized = checkBox_show_imageColorized.Checked;
            pictureBox1.Image = bShow_imageColorized ? imageColorized : image;
        }

        private void slider_colorizeRange_Scroll(object sender, EventArgs e)
        {
            hsvrgb.H_mod = (int)(180 *Math.Pow( slider_colorizeRange.Value,1.5));
        }


    }

    enum ColorizeType
    {
        fill_histH,
        fill_histHabs,
        fill_histHmod,
        fill_clear,
        drawState,
        fill_histH_eachStep_skipBG
    }

    
    enum ColorizeSkipBGType
    {
        none,
        skipBG,
        skip0,
        skipOld
    }
}
//2020.8.10 pavel.b.kr12
