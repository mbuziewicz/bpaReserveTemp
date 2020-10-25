System.Diagnostics.Debug.WriteLine("SomeText");

Added functionality with Viewbag so that you could pass info to another form.  

This is from restcards to reservesection (restaurant) 

Fixed some strange error about UserID was inserted twice.  I had to rename the userid field in the user table

had a strange error about the database missing fields.  To fix it, I had to create brand new project with accounts turned on and did the migration and update database.  This fixed it.

finally got the microsoft login userid to populate the make reservation table.

added the files for the identity code pages.  They were not there.  I selected all of them and used to option to override all of them.  It works.

The process of updating seems to be make changes to the models/whatever.cs files.  This breaks it.  You have to fix what is broken. Many times you need to delete all of the scaffolded files (create, index, etc.) and the when there are no issues run the migration and update.

I had to delete the database and the migrations manually a couple of times to get rid of some quirky errors.  Deleted everything and then ran the migration / updates again.

Do not delete the BpaReserveContext.cs or ApplicationDbContext.cs!!
-or- delete the code in the startup.cs for it.
Migrations does not bring them back!!

Added .AddRoles<IdentityRole>()
Otherwise, the identity would not work!!
This is in the startup.cs file.

            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(
                 Configuration.GetConnectionString("DefaultConnection")));
                    services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                        .AddRoles<IdentityRole>()
                        .AddEntityFrameworkStores<ApplicationDbContext>();

There are two links that I added in the Canvas Object oriented course about identity.  Showed how to add the needed fields manually to identity tables so that you can have an admin.

[Authorize(Roles = "Admin")] in each of the index files.
Added "Admin" to AspNetRoles table, etc.  (see link in canvas "Create Identity In a Simple Way Using ASP.NET MVC 5 - Part TwoLinks to an external site.
")




