using Final_Task_7;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using static Final_Task_7.Helper;

/*
 * Started: 21.03.22
 * Ended: 23.03.22
 */
namespace Final_Module_7_Console
{
    internal class Program
    {
        public static Customer customer;

        static void Main(string[] args)
        {

            string enterResult = "";
            while (enterResult != "exit")
            {
                List<Product> itemsList = new();
                while (true)
                {
                    if (itemsList.Count > 0) Order<Delivery>.PrintCart(itemsList);
                    Print("Выберите товары из списка", ConsoleColor.Yellow);
                    foreach (var item in items)
                    {
                        Print($"[{item.Id}] {item.Name} | " +
                            $"Цена:{(item.Price - (item.Sale > 0 ? item.Price / 100 * item.Sale : 0))}тг. | " +
                            $"{(item.Sale > 0 ? $"Скидка: {item.Price / 100 * item.Sale}тг. ({item.Sale}%)" : "Без скидки")} | " +
                            $"{(item.Count > 0 ? $"Осталось {item.Count}" : "Закончились")}",
                            item.Count > 0 ? ConsoleColor.Cyan : ConsoleColor.DarkGray);
                    }
                    Print("Введите идентификатор товара\n" +
                          "Для завершения введите 0", ConsoleColor.Yellow);
                    if (int.TryParse(Console.ReadLine().Trim(), out int index))
                    {
                        if (index == 0)
                        {
                            if (itemsList.Count > 0)
                                break;
                            else
                            {
                                Console.Clear();
                                Print("С пустой корзиной нельзя перейти к заказу.", ConsoleColor.Red);
                            }
                        }
                        else
                        {
                            if (items.Exists(pred => pred.Id == index))
                            {
                                var findedItem = items.Find(pred => pred.Id == index);
                                if (findedItem.Count > 0)
                                {
                                enterCount: Console.WriteLine("Введите количество");
                                    if (uint.TryParse(Console.ReadLine().Trim(), out uint count))
                                    {
                                        if (count > 0)
                                        {
                                            if (count > findedItem.Count)
                                            {
                                                Print($"Максимальное количество для заказа - {findedItem.Count}", ConsoleColor.Red);
                                                goto enterCount;
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                items[items.IndexOf(findedItem)].Count -= count;
                                                itemsList.Add(findedItem);
                                                Print($"Товар {findedItem.Name} добавлен! x{count}", ConsoleColor.Green);
                                            }
                                        }
                                        else
                                        {
                                            Print("Минимальное количество - 1!", ConsoleColor.Red);
                                            goto enterCount;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Print("К сожалению товар закончился. :(", ConsoleColor.Red);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Print($"Товар с идентификатором {index} не найден!", ConsoleColor.Red);
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Print($"Идентификатор должен быть числом!", ConsoleColor.Red);
                    }

                }
                if (customer == null)
                    customer = new Customer();
                else
                {
                    Print($"Хотите заново заполнить анкету пользователя {customer.Name}? (да/нет)", ConsoleColor.Yellow);
                    if (Console.ReadLine().Trim().ToLower() == "да")
                    {
                        customer = new Customer();
                    }
                }
            enterpayment: Console.WriteLine(
                        "Выберите тип оплаты\n" +
                        "1 - Наличными\n" +
                        "2 - Безналичная");
                int.TryParse(Console.ReadLine(), out int pt);
                if (pt < 1 || pt > 2)
                {
                    Print("Неправильный ввод, повторите ввод типа оплаты", ConsoleColor.Red);
                    goto enterpayment;
                }
            enterDeliveryType: Print("Введите тип доставки\n" +
                "1 - Доставка на дом\n" +
                "2 - Доставку в пункт выдачи\n" +
                "3 - Доставка в розничный магазин", ConsoleColor.Yellow);

                if (!int.TryParse(Console.ReadLine(), out int deltype)) goto enterDeliveryType;
                switch (deltype)
                {
                    case 1:
                        {
                            Order<HomeDelivery> order = new(itemsList);
                            Print("Введите адресс доставки", ConsoleColor.Yellow);
                            string address = Console.ReadLine();

                            Print("Введите комментарий", ConsoleColor.Yellow);
                            string comment = Console.ReadLine();

                            Print("Доставить как можно скорее?", ConsoleColor.Yellow);

                            if (Console.ReadLine().Trim().ToLower() == "да")
                            {
                                order.PlaceOrder(new HomeDelivery(address), customer, comment, (PaymentType)pt - 1);
                            }
                            else
                            {
                                Print("Желаемая дата доставки (dd.mm.yyyy hh:mm)", ConsoleColor.Yellow);
                                string wishdate = Console.ReadLine().Trim();
                                order.PlaceOrder(
                                    DateTime.TryParse(wishdate, out DateTime dt) ? new HomeDelivery(address, dt) : new HomeDelivery(address),
                                    customer, comment, (PaymentType)pt - 1);
                            }
                            Print("Заказ создан!", ConsoleColor.Green);
                            order.CheckOrder();
                            Thread.Sleep(1000);
                            order.ChangeOrderState(OrderState.OnDelivery);
                            order.CheckOrder();
                            Thread.Sleep(1000);
                            order.ChangeOrderState(OrderState.Delivered);
                            order.CheckOrder();
                        }
                        break;
                    case 2:
                        {
                            Order<PickPointDelivery> order = new(itemsList);
                            Print("Введите комментарий", ConsoleColor.Yellow);
                            string comment = Console.ReadLine();
                        enterpp: Print("Выберите адресс доставки", ConsoleColor.Yellow);
                            PrintAdresses(pickPoints);
                            if (int.TryParse(Console.ReadLine().Trim(), out int pp))
                            {
                                if (pp >= 0 && pp < pickPoints.Count)
                                    order.PlaceOrder(new PickPointDelivery(pickPoints[pp]), customer, comment, (PaymentType)pt - 1);
                                else
                                {
                                    Print("Введеного адреса не существует.", ConsoleColor.Red); goto enterpp;
                                }
                            }
                            else
                            {
                                Print("Вводить нужно цифру.", ConsoleColor.Red); goto enterpp;
                            }
                            Print("Заказ создан!", ConsoleColor.Green);
                            order.CheckOrder();
                            Thread.Sleep(1000);
                            order.ChangeOrderState(OrderState.OnDelivery);
                            order.CheckOrder();
                            Thread.Sleep(1000);
                            order.ChangeOrderState(OrderState.Delivered);
                            order.CheckOrder();
                        }
                        break;
                    case 3:
                        {
                            Order<ShopDelivery> order = new(itemsList);
                            Print("Введите комментарий", ConsoleColor.Yellow);
                            string comment = Console.ReadLine();
                        entersp: Print("Выберите адресс доставки", ConsoleColor.Yellow);
                            PrintAdresses(shopPoints);
                            if (int.TryParse(Console.ReadLine().Trim(), out int sp))
                            {
                                if (sp >= 0 && sp < pickPoints.Count)
                                    order.PlaceOrder(new ShopDelivery(pickPoints[sp]), customer, comment, (PaymentType)pt - 1);
                                else
                                {
                                    Print("Введеного адреса не существует.", ConsoleColor.Red); goto entersp;
                                }
                            }
                            else
                            {
                                Print("Вводить нужно цифру.", ConsoleColor.Red); goto entersp;
                            }
                            Print("Заказ создан!", ConsoleColor.Green);
                            order.CheckOrder();
                            Thread.Sleep(1000);
                            order.ChangeOrderState(OrderState.OnDelivery);
                            order.CheckOrder();
                            Thread.Sleep(1000);
                            order.ChangeOrderState(OrderState.Delivered);
                            order.CheckOrder();
                        }
                        break;
                    default: Print("Неверный тип доставки.", ConsoleColor.Red); break;
                }

                enterResult = Console.ReadLine();
            }
        }
    }
}
