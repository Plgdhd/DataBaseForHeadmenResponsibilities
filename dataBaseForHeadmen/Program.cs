using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using (ApplicationContext db = new ApplicationContext())
{
    while (true)
    {
        Console.Write("Выберите вариант:\n1 - Заполнить ФИО группы\n2 - Очистить базу данных нахуй\n3 - вывод БД\n4 - Внести пропуск\n5 - своя операция\n6 - Выход\nВаш выбор: ");
        int answer = Convert.ToInt32(Console.ReadLine());
        var users = db.Users.ToList();
        switch (answer) {
            case 1:
                {
                    User[] persons = new User[30];
                    persons = InitMembersOfGroup(persons);
                    foreach (var user in persons)
                    {
                        db.Users.Add(user);
                    }
                    db.SaveChanges();
                    Console.WriteLine("Объекты успешно сохранены");

                }
                break;
            case 2:
                {
                    foreach(var user in users)
                    {
                        user.KYAR = 0;
                        user.Bel_mova = 0;
                        user.OAIP = 0;
                        user.OPI = 0;
                        user.Alovs_practice = 0;
                        user.Linal_practice = 0;
                        user.Matan_practice = 0;
                        user.English = 0;
                        user.total_hours = 0;

                    }
                    db.SaveChanges();
                    Console.WriteLine("Объекты успешно сохранены");

                }
                break;
            case 3:
                {
                    Console.WriteLine("Список объектов:");
                    int i = 1;
                    foreach (User u in users)
                    {
                        u.Id = i;
                        i++;
                        Console.WriteLine($"{u.Id}.{u.Name} общее кол-во часов по неуважительной: {u.total_hours}");
                    }
                    break;
                }
            case 4:
                {
                    int number = 1, disp = 1, answ;
                    bool change = true;
                    while (change)
                    {
                        Console.Write("Выберите номер в списке: ");
                        number = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.WriteLine("\nПредмет:\n1 - КЯР\n2 - ОАИП\n3 - ОПИ\n4 - Английский\n5 - Бел яз\n6 - АЛОВС\n7 - МАТАН\n8 - ЛИНАЛ");
                        Console.Write("Ваш выбор: ");
                        disp = Convert.ToInt32(Console.ReadLine());
                        switch (disp)
                        {
                            case 1:
                                users[number].KYAR += 2;
                                users[number].total_hours += 2;
                                break;
                            case 2:
                                users[number].OAIP += 2;
                                users[number].total_hours += 2;
                                break;
                            case 3:
                                users[number].OPI += 2;
                                users[number].total_hours += 2;
                                break;
                            case 4:
                                users[number].English += 2;
                                users[number].total_hours += 2;
                                break;
                            case 5:
                                users[number].Bel_mova += 2;
                                users[number].total_hours += 2;
                                break;
                            case 6:
                                users[number].Alovs_practice += 2;
                                users[number].total_hours += 2;
                                break;
                            case 7:
                                users[number].Matan_practice += 2;
                                users[number].total_hours += 2;
                                break;
                            case 8:
                                users[number].Linal_practice += 2;
                                users[number].total_hours += 2;
                                break;
                            default: Console.WriteLine("Ошибочный выбор!"); break;
                        }
                        db.SaveChanges();
                        Console.WriteLine("\nХотите еще внести пропуск? (Да - 1/Нет - 2)");
                        Console.Write("Ваш выбор: ");
                        answ = Convert.ToInt32(Console.ReadLine());
                        change = answ == 1 ? true: false;
                    }

                }
                break;
            case 5:
                {
                    break;
                }
            case 6: {
                    return;
                }
            default: continue;
        }
    }
}
static User[] InitMembersOfGroup(User[] users)
{
    for(int i=0; i<users.Length; i++)
    {
        users[i] = new User();
        Console.Write($"Введите ФИО номера {i+1}:");
        users[i].Name = Console.ReadLine();
        
    }
    return users;
}