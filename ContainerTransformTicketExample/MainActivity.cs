using AndroidX.AppCompat.App;
using ContainerTransformTicketExample.ui.fragments;

namespace ContainerTransformTicketExample;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : AppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);

        var fragmentDestination = new HomeFragment();
        var fragmentTransaction = SupportFragmentManager.BeginTransaction();
        fragmentTransaction
            .Replace(Resource.Id.app_nav_host_fragment, fragmentDestination)
            .Commit();
    }
}