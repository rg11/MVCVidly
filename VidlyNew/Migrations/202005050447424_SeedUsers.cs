namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8ca32e66-06c6-44b8-be68-74cafb88a592', N'rakhigupta01@gmail.com', 0, N'AO0JHARh3+6XNaULyxkc+5PKIRmgWzqB8S0FjKw/qGcgrODV7KezwsUttmab/LR0lg==', N'a4d01f4b-1a40-48fd-90b1-ef486a93df73', NULL, 0, 0, NULL, 1, 0, N'rakhigupta01@gmail.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c96ac056-f222-4718-9c32-6072be1a47a4', N'admin@vidly.com', 0, N'AOcToeRr3gcOJIaWRMarpv0TebbHrgmmNIJQxT8THQuAAGKGghtb4tVyVsYmCilaxw==', N'36741a4d-5d77-4782-b86f-9ae714185b01', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')


                    INSERT INTO[dbo].[AspNetRoles] ([Id], [Name]) VALUES(N'83f205ef-7ad4-439e-9914-c66f5bbda880', N'CanManageMovies')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c96ac056-f222-4718-9c32-6072be1a47a4', N'83f205ef-7ad4-439e-9914-c66f5bbda880')

                ");
        }
        
        public override void Down()
        {
            
        }
    }
}
