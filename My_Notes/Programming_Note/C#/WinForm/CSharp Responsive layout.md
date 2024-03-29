# Responsive layout

tags: #c_sharp 

[Reference:ITRead](https://www.itread01.com/content/1515752429.html)

[Reference:ITRead](https://www.itread01.com/content/1542271084.html)

---

在寫`.net winform`時深刻地感受到響應式網頁是個好東西，因此查詢了下作法



其實道理很簡單，當表單改變大小時觸發事件(預設就有SizeChanged事件了)改變控制項的大小。

以下是別人寫好的範例

```C#
using System;  
using System.Collections.Generic;  
using System.Text;  
using System.Windows.Forms;  
namespace WindowsApplication1  
{  
    class AutoSizeFormClass  
    {  
        //(1).聲明結構,只記錄窗體和其控件的初始位置和大小。  
        public struct controlRect  
        {  
            public int Left;  
            public int Top;  
            public int Width;  
            public int Height;  
        }  
        //(2).聲明 1個對象  
        //註意這裏不能使用控件列表記錄 List<Control> nCtrl;，因為控件的關聯性，記錄的始終是當前的大小。  
         public List<controlRect> oldCtrl;  
        //int ctrl_first = 0;  
        //(3). 創建兩個函數  
        //(3.1)記錄窗體和其控件的初始位置和大小,  
        public void controllInitializeSize(Form mForm)  
        {  
            // if (ctrl_first == 0)  
            {  
                //  ctrl_first = 1;  
                oldCtrl = new List<controlRect>();  
                controlRect cR;  
                cR.Left = mForm.Left; cR.Top = mForm.Top; cR.Width = mForm.Width; cR.Height = mForm.Height;  
                oldCtrl.Add(cR);  
                foreach (Control c in mForm.Controls)  
                {  
                    controlRect objCtrl;  
                    objCtrl.Left = c.Left; objCtrl.Top = c.Top; objCtrl.Width = c.Width; objCtrl.Height = c.Height;  
                    oldCtrl.Add(objCtrl);  
                }  
            }  
            // this.WindowState = (System.Windows.Forms.FormWindowState)(2);//記錄完控件的初始位置和大小後，再最大化  
            //0 - Normalize , 1 - Minimize,2- Maximize  
        }  
        //(3.2)控件自適應大小,  
        public void controlAutoSize(Form mForm)  
        {  
            //int wLeft0 = oldCtrl[0].Left; ;//窗體最初的位置  
            //int wTop0 = oldCtrl[0].Top;  
            ////int wLeft1 = this.Left;//窗體當前的位置  
            //int wTop1 = this.Top;  
            float wScale = (float)mForm.Width / (float)oldCtrl[0].Width;//新舊窗體之間的比例，與最早的舊窗體  
            float hScale = (float)mForm.Height / (float)oldCtrl[0].Height;//.Height;  
            int ctrLeft0, ctrTop0, ctrWidth0, ctrHeight0;  
            int ctrlNo = 1;//第1個是窗體自身的 Left,Top,Width,Height，所以窗體控件從ctrlNo=1開始  
            foreach (Control c in mForm.Controls)  
            {  
                ctrLeft0 = oldCtrl[ctrlNo].Left;  
                ctrTop0 = oldCtrl[ctrlNo].Top;  
                ctrWidth0 = oldCtrl[ctrlNo].Width;  
                ctrHeight0 = oldCtrl[ctrlNo].Height;  
                //c.Left = (int)((ctrLeft0 - wLeft0) * wScale) + wLeft1;//新舊控件之間的線性比例  
                //c.Top = (int)((ctrTop0 - wTop0) * h) + wTop1;  
                c.Left = (int)((ctrLeft0) * wScale);//新舊控件之間的線性比例。控件位置只相對於窗體，所以不能加 + wLeft1  
                c.Top = (int)((ctrTop0) * hScale);//  
                c.Width = (int)(ctrWidth0 * wScale);//只與最初的大小相關，所以不能與現在的寬度相乘 (int)(c.Width * w);  
                c.Height = (int)(ctrHeight0 * hScale);//  
                ctrlNo += 1;  
            }  
        }  

    }  
}  
```



---

不過實際使用上，根據需求去改變控制項大小比較方便

例如這次的作法

```C#
        private void frmBase_Load(object sender, EventArgs e)
        {
            formHeight = Height;
            formWidth = Width;
        }

        private void frmBase_SizeChanged(object sender, EventArgs e)
        {
            if(Height>400)
            {
                changeSizeH(Height - formHeight);
                formHeight = Height;
            }
            if(Width>900)
            {
                changeSizeW(Width - formWidth);
                formWidth = Width;
            }
            void changeSizeH(int difHeight)
            {
                tbxLog.Height += difHeight;
                btnNext.Top += difHeight;
                btnPrevious.Top += difHeight;
                lblMaxPage.Top += difHeight;
                tbxPage.Top += difHeight;
            }
            void changeSizeW(int difWidth)
            {
                tbxLog.Width += difWidth;
                btnNext.Left += difWidth;
                btnPrevious.Left += difWidth;
                lblMaxPage.Left += difWidth;
                tbxPage.Left += difWidth;
            }
        }
```

