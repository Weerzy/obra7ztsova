using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrgManagmentApp.Models;

namespace OrgManagmentApp.Db;

public class DatabaseInitializer
{
    private readonly AppDbContext _context;

    public DatabaseInitializer(AppDbContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync()
    {
        try
        {
            // Создаем базу данных, если она не существует
            await _context.Database.MigrateAsync();
            
            // Проверяем, нужно ли инициализировать начальные данные
            if (!await _context.Users.AnyAsync())
            {
                await SeedDataAsync();
            }
            if (!_context.Organizations.Any())
        {
            var organizations = new List<Organization>
            {
                new Organization
                {
                    Name = "ООО Технологии будущего",
                    Email = "info@techfuture.ru",
                    PhoneNumber = "+7 (495) 123-45-67"
                },
                new Organization
                {
                    Name = "ИП Иванов",
                    Email = "ivanov@business.ru",
                    PhoneNumber = "+7 (495) 765-43-21"
                },
                new Organization
                {
                    Name = "АО Инновации",
                    Email = "contact@innovations.ru",
                    PhoneNumber = "+7 (499) 999-88-77"
                }
            };

            _context.Organizations.AddRange(organizations);
            await _context.SaveChangesAsync();
        }

        if (!_context.Organizers.Any())
        {
            var organizers = new List<Organizer>
            {
                new Organizer
                {
                    LastName = "Петров",
                    FirstName = "Иван",
                    MiddleName = "Сергеевич",
                    OrganizationID = 1,
                    Email = "petrov@techfuture.ru",
                    PhoneNumber = "+7 (916) 111-22-33"
                },
                new Organizer
                {
                    LastName = "Иванов",
                    FirstName = "Петр",
                    MiddleName = "Александрович",
                    OrganizationID = 2,
                    Email = "p.ivanov@business.ru",
                    PhoneNumber = "+7 (917) 444-55-66"
                },
                new Organizer
                {
                    LastName = "Сидорова",
                    FirstName = "Мария",
                    MiddleName = "Ивановна",
                    OrganizationID = 3,
                    Email = "m.sidorova@innovations.ru",
                    PhoneNumber = "+7 (915) 777-88-99"
                }
            };

            _context.Organizers.AddRange(organizers);
            await _context.SaveChangesAsync();
        }
        if (!_context.EventCategories.Any())
        {
            var categories = new List<EventCategory>
            {
                new EventCategory
                {
                    Name = "Конференция",
                    Description = "Масштабное мероприятие для обмена опытом и знаниями между специалистами"
                },
                new EventCategory
                {
                    Name = "Семинар",
                    Description = "Групповое обучающее мероприятие с практическими занятиями"
                },
                new EventCategory
                {
                    Name = "Мастер-класс",
                    Description = "Интерактивное занятие с демонстрацией практических навыков"
                },
                new EventCategory
                {
                    Name = "Выставка",
                    Description = "Демонстрация достижений в области науки, техники, искусства"
                },
                new EventCategory
                {
                    Name = "Форум",
                    Description = "Площадка для обсуждения актуальных вопросов и networking"
                },
                new EventCategory
                {
                    Name = "Фестиваль",
                    Description = "Праздничное мероприятие, объединяющее различные виды искусства или деятельности"
                }
            };

            _context.EventCategories.AddRange(categories);
            await _context.SaveChangesAsync();
        }
        if (!_context.EventAddresses.Any())
        {
            var addresses = new List<EventAddress>
            {
                new EventAddress
                {
                    Address = "ул. Ленина, 1",
                    VenueNumber = "301",
                    Capacity = 50
                },
                new EventAddress
                {
                    Address = "пр. Мира, 15",
                    VenueNumber = "А-100",
                    Capacity = 150
                },
                new EventAddress
                {
                    Address = "ул. Пушкина, 7",
                    VenueNumber = "Конференц-зал",
                    Capacity = 200
                },
                new EventAddress
                {
                    Address = "ул. Гагарина, 25",
                    VenueNumber = "205",
                    Capacity = 75
                }
            };

            _context.EventAddresses.AddRange(addresses);
            await _context.SaveChangesAsync();
        }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    private async Task SeedDataAsync()
    {
        string adminPassword = "admin123"; // Стандартный пароль
        var password = BCrypt.Net.BCrypt.HashPassword(adminPassword);

        // Создание ролей
        await _context.Roles.AddRangeAsync(
            new Role { ID = 1, Name = "Administrator", Description = "Администратор системы" },
            new Role { ID = 2, Name = "User", Description = "Обычный пользователь" }
        );
        
        await _context.Levels.AddRangeAsync(
            new Level { ID = 1, Name = "Базовый", Description = "Базовый уровень доступа" },
            new Level { ID = 2, Name = "Премиум", Description = "Премиум уровень доступа" },
            new Level { ID = 3, Name = "VIP", Description = "VIP уровень доступа" }
        );

        // Создание учетной записи администратора
        await _context.Users.AddAsync(
            new User
            {
                ID = 1,
                FirstName = "Admin",
                LastName = "Adminov",
                MiddleName = "yo",
                Email = "admin@example.com",
                Login = "admin",
                PasswordHash = password,
                RoleID = 1 // Роль администратора
            }
        );
        // Создаем роли
        await _context.SaveChangesAsync();
    }
}