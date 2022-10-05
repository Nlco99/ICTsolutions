using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICTsolutions.Migrations
{
    public partial class SeedRoles : Migration
    {

        private string ManagerRoleId = Guid.NewGuid().ToString();
        private string UserRoleId = Guid.NewGuid().ToString();
        private string AdminRoleId = Guid.NewGuid().ToString();


        private string User1Id = Guid.NewGuid().ToString();
        private string User2Id = Guid.NewGuid().ToString();


        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);

            SeedUser(migrationBuilder);

            SeedUserRoles(migrationBuilder);
        }

        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName],[ConcurrencyStamp])
            VALUES ('{AdminRoleId}', 'Administrator', 'ADMINISTRATOR', null);");
            migrationBuilder.Sql($@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName],[ConcurrencyStamp])
            VALUES ('{ManagerRoleId}', 'Manager', 'MANAGER', null);");
            migrationBuilder.Sql($@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName],[ConcurrencyStamp])
            VALUES ('{UserRoleId}', 'User', 'USER', null);");
        }


        private void SeedUser(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                $@"INSERT [dbo].[AspNetUsers] ([Id], [FirstName],[LastName], [UserName], [NormalizedUserName],
                [Email], [NormalizedEmail],[EmailConfirmed],[PasswordHash],[SecurityStamp],[ConcurrencyStamp]
                ,[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnd],[LockoutEnabled],[AccessFailedCount])
                VALUES
                (N'{User1Id}', N'test1', N'Lastname', N'manager1@test.com', N'MANAGER1@TEST.COM', 
                N'manager1@test.com',N'MANAGER1@TEST.COM', N'0',
                N'AQAAAAEAACcQAAAAEJxPiTt8WQT/J398/T/9wRDyOlHfIpWGbdAneS1wz38x/1geaRGTXUX9cE/l1Z22fA==',
                N'LOEFKKCMI3KJRKTYNUSN5LVRI22ZMCJZ', N'ad139658-3969-491a-b704-3046b1dd2e48', NULL, 0, 0, NULL, 1, 0)");

            migrationBuilder.Sql(
                $@"INSERT [dbo].[AspNetUsers] ([Id], [FirstName],[LastName], [UserName], [NormalizedUserName],
                [Email], [NormalizedEmail],[EmailConfirmed],[PasswordHash],[SecurityStamp],[ConcurrencyStamp]
                ,[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnd],[LockoutEnabled],[AccessFailedCount])
                VALUES
                (N'{User2Id}', N'test2', N'Lastname', N'admin1@test.com', N'ADMIN1@TEST.COM', 
                N'admin1@test.com',N'ADMIN1@TEST.COM', N'0',
                N'AQAAAAEAACcQAAAAEHAcYSpxpO1OsglAa9LjM3O+6nGQ4E4GeWH4HKvzmMz/ky7FgLO4SpNodFj6f3JJ3w==',
                N'X5R5XSHVIRZPXRA6LDA24RNJJB5USKFU', N'9b322149-54f3-4074-97e0-5124e887571b', NULL, 0, 0, NULL, 1, 0)");

        }

        private void SeedUserRoles(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql($@"
            INSERT [dbo].[AspNetUserRoles]
                ([UserId]
                ,[RoleId])
           VALUES
               ('{User1Id}', '{ManagerRoleId}');
            INSERT [dbo].[AspNetUserRoles]
                ([UserId]
                ,[RoleId])
           VALUES
               ('{User1Id}', '{UserRoleId}');");

            migrationBuilder.Sql($@"
            INSERT [dbo].[AspNetUserRoles]
                ([UserId]
                ,[RoleId])
           VALUES
               ('{User2Id}', '{AdminRoleId}');
            INSERT [dbo].[AspNetUserRoles]
                ([UserId]
                ,[RoleId])
           VALUES
               ('{User2Id}', '{ManagerRoleId}');");

        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
