using ContainerTransformTransitionAndroid.ui.home.fragments;
using AndroidX.AppCompat.App;
using Fragment = AndroidX.Fragment.App.Fragment;

namespace ContainerTransformTransitionAndroid;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : AppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);
        
        NavigateToFragment(new HomeFragment());
    }
    
    private void NavigateToFragment(
        Fragment fragmentNavigateTo,
        bool replaceStack = true)
    {
        var fragmentTransaction = SupportFragmentManager.BeginTransaction();

        if (replaceStack)
        {
            fragmentTransaction
                .Replace(Resource.Id.app_nav_host_fragment, fragmentNavigateTo)
                .Commit();
        }
        else
        {
            fragmentTransaction
                .Add(Resource.Id.app_nav_host_fragment, fragmentNavigateTo)
                .AddToBackStack(fragmentNavigateTo.GetType().Name)
                .Commit();
        }
    }
}