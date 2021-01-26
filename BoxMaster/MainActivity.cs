using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace BoxMaster
{
    

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView seView;
        TextView seLength;
        SeekBar sBar;
        SeekBar vBar;
        EditText vText; 
         EditText   HZ;
        EditText eSabwufer;
        EditText eArea;
                

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            HZ = FindViewById<EditText>(Resource.Id.HZ);
            vText = FindViewById<EditText>(Resource.Id.vText);
            sBar = FindViewById<SeekBar>(Resource.Id.sBar);
            vBar = FindViewById<SeekBar>(Resource.Id.vBar);
            seLength = FindViewById<TextView>(Resource.Id.seLength);
            seView = FindViewById<TextView>(Resource.Id.seView);
            eSabwufer = FindViewById<EditText>(Resource.Id.eSabwufer);
            eArea = FindViewById<EditText>(Resource.Id.eArea);
            HZ.TextChanged += HerzEdit;
            vText.TextChanged += VoluemCharged;
            sBar.ProgressChanged += sBarCharged;
            vBar.ProgressChanged += vBarCharged;
            eArea.TextChanged += eAreaCharged;
            eSabwufer.TextChanged += eSabwuferCharged;

            

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        void eAreaCharged(object sender, EventArgs e)
        {
            if ((eArea.Length() > 0) && (Convert.ToInt32(eArea.Text)!=0) && (eSabwufer.Length() > 0) && (Convert.ToInt32(eSabwufer.Text) != 0))
            {
                int x = Convert.ToInt32(Count.AreaP(Convert.ToInt32(eArea.Text), Convert.ToInt32(eSabwufer.Text)) * 0.6);
                sBar.Max = x * 2;
                sBar.Progress = x;
            }
        }


        void eSabwuferCharged(object sender, EventArgs e)
        {
            if ((eArea.Length() > 0) && (Convert.ToInt32(eArea.Text) != 0) && (eSabwufer.Length() > 0) && (Convert.ToInt32(eSabwufer.Text) != 0))
            {
                int x = Convert.ToInt32(Count.AreaP(Convert.ToInt32(eArea.Text), Convert.ToInt32(eSabwufer.Text)) * 0.6);
                sBar.Max = x * 2;
                sBar.Progress = x;

            }
        }
        void HerzEdit(object sender, EventArgs e)
        {
          

        }
        void VoluemCharged(object sender, EventArgs e)
        {

        }
        void sBarCharged(object sender, EventArgs e)
        {
            if (vText.Length() > 0 && HZ.Length() > 0)
            {
                int s = Convert.ToInt32(vText.Text);
                int F = Convert.ToInt32(HZ.Text);
                if (s > 0 && F > 0)
                {
                    seView.Text = sBar.Progress.ToString() + " СМ^2";
                    double l = Count.length(sBar.Progress, s, F);
                    vBar.Max = (int)l * 2;
                    vBar.Progress = (int)l;
                }
            }
            //seLength.Text = l.ToString();
        
        }
        void vBarCharged (object sender, EventArgs e)
        {
            int v = Convert.ToInt32(vText.Text);
            int s = sBar.Progress;
            seLength.Text = vBar.Progress.ToString()+"см";
            int l = vBar.Progress;
            HZ.Text = Convert.ToInt32(Count.Freq(l, s, v)).ToString();
        }
        

    }

    


}