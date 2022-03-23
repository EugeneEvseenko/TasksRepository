using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
/*
 * Started: 21.03.22
 * Ended: 23.03.22
 */
namespace Final_Task_7
{
    /// <summary>
    /// Вспомогательный статический класс
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Упрощенный вывод строки в терминал с выбором цвета
        /// </summary>
        /// <param name="line">Строка для вывода.</param>
        /// <param name="color">Цвет строки.</param>
        /// <param name="lineBreak">Перенос строки. По умолчанию включен.</param>
        public static void Print(string line, ConsoleColor color = ConsoleColor.White, bool lineBreak = true)
        {
            Console.ForegroundColor = color;
            if (lineBreak)
                Console.WriteLine(line);
            else
                Console.Write(line);
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Печать в терминал адресов магазинов/пунктов самовывоза
        /// </summary>
        /// <typeparam name="TPoints">Тип точки</typeparam>
        /// <param name="points">Список адресов</param>
        public static void PrintAdresses<TPoints>(List<TPoints> points) where TPoints : Shop
        {
            for (int i = 0; i < points.Count; i++)
            {
                Print($"[{i + 1}] {points[i]}", ConsoleColor.Cyan);
            }
        }
        public static List<Product> items = new()
        {
            new Product("Смартфон Apple iPhone 11 128GB Black", 404990, 0),
            new Product("Телевизор Samsung 50\" UE50AU8000UXCE LED UHD Smart Black", 379990, 20, 20),
            new Product("Пылесос Tefal TW-7260EA", 147990, 1),
            new Product("Стиральная машина LG F-2V5HS0W", 239990, 4, 2),
            new Product("Встраиваемая духовка Bosch HBF-534EB0Q", 281990, 18, 10),
            new Product("Вытяжка Bosch DFT-63CA60Q", 89990, 9, 0),
            new Product("Фильтр для вытяжки угольный+жиропоглощающий с индикатором TOP HOUSE 392241", 3990, 7)
        };
        public static List<Manager> managers { get; set; } = new()
        {
            new Manager("Марина", "marina@shop.kz", "+7(707)175-99-38"),
            new Manager("Олег", "oleg@shop.kz", "+7(707)175-99-38"),
            new Manager("Артем", "artem@shop.kz", "+7(707)175-99-38"),
            new Manager("Андрей", "andrey@shop.kz", "+7(707)175-99-38")
        };
        public static List<Shop> shopPoints = new()
        {
            new Shop { Address = "Наурызбай батыра, 49", WorkDays = "Ежедневно", WorkTimeStart = "10:00", WorkTimeStop = "22:00" },
            new Shop { Address = "проспект Райымбека, 127/147", WorkDays = "Ежедневно", WorkTimeStart = "10:00", WorkTimeStop = "22:00" },
            new Shop { Address = "​Толе би, 187", WorkDays = "Ежедневно", WorkTimeStart = "10:00", WorkTimeStop = "22:00" },
            new Shop { Address = "​Жандосова, 34а", WorkDays = "Ежедневно", WorkTimeStart = "10:00", WorkTimeStop = "22:00" },
            new Shop { Address = "​Кабдолова, 1/8", WorkDays = "Ежедневно", WorkTimeStart = "10:00", WorkTimeStop = "22:00" }
        };
        public static List<PickPoint> pickPoints = new()
        {
            new PickPoint { CompanyName = "KazPost", Address = "Наурызбай батыра, 49", WorkDays = "Пн-Пт", WorkTimeStart = "10:00", WorkTimeStop = "20:00" },
            new PickPoint { CompanyName = "DHL", Address = "проспект Райымбека, 127/147", WorkDays = "Ежедневно", WorkTimeStart = "10:00", WorkTimeStop = "22:00" },
            new PickPoint { CompanyName = "UPS", Address = "​Толе би, 187", WorkDays = "Ежедневно", WorkTimeStart = "10:00", WorkTimeStop = "22:00" },
            new PickPoint { CompanyName = "SDEK", Address = "​Жандосова, 34а", WorkDays = "Ежедневно", WorkTimeStart = "10:00", WorkTimeStop = "22:00" },
        };
    }
    /// <summary>
    /// Состояния заказа
    /// </summary>
    public enum OrderState
    {
        /// <summary>
        /// Заказ ожидает создания.
        /// Данный статус означает, что заказ еще не создан.
        /// </summary>
        WaitingToCreate,
        /// <summary>
        /// Заказ создан.
        /// Данный статус означает, что заказ успешно создан 
        /// и в ближайшее время с ним начнет работать менеджер.
        /// </summary>
        Created,
        /// <summary>
        /// Заказ принят.
        /// С заказом начал работать менеджер, который после смены 
        /// статуса на «Принят» уточняет наличие товара на складах компании.
        /// </summary>
        Adopted,
        /// <summary>
        /// Ожидает оплаты.
        /// Статус используется в случаях, если необходимо внести предоплату 
        /// для дальнейшей работы менеджера с заказом.
        /// </summary>
        AwaitingPayment,
        /// <summary>
        /// Ожидает отправки.
        /// Заказ подготавливается к отправке в пункт отгрузки.
        /// </summary>
        WaitingToSent,
        /// <summary>
        /// Ожидает поступления на склад.
        /// Данный статус означает, что товар по заказу готовится к отправке 
        /// на склад магазина.
        /// </summary>
        AwaitingReceipt,
        /// <summary>
        /// Заказан у поставщика.
        /// При оформлении заказа на товар, которого нет в каталоге магазина
        /// и внесении предоплаты, заказ переходит в данный статус.
        /// </summary>
        OrderedFromSupplier,
        /// <summary>
        /// Готов к доставке.
        /// Данный статус означает, что товар поступил на склад отгрузки для 
        /// дальнейшей доставки.
        /// </summary>
        ReadyToDelivery,
        /// <summary>
        /// Посылка сформирована.
        /// Если ваш заказ находится в данном статусе, это значит, что товар 
        /// тщательно упакован и в ближайшее время будет передан в службу 
        /// почтовой доставки.
        /// </summary>
        PackageIsFormed,
        /// <summary>
        /// На доставке.
        /// Заказ был передан в службу доставки и курьер осуществляет доставку
        /// на указанный вами адрес, либо в пункт приема почтовых отправлений.
        /// </summary>
        OnDelivery,
        /// <summary>
        /// Доставлен.
        /// Статус ставится менеджером интернет-магазина после того как заказ получен.
        /// </summary>
        Delivered
    }
    /// <summary>
    /// Тип оплаты заказа
    /// </summary>
    public enum PaymentType
    {
        /// <summary>
        /// Наличная оплата
        /// </summary>
        Cash,
        /// <summary>
        /// Безналичная оплата
        /// </summary>
        Cashless
    }
    /// <summary>
    /// Абстрактный класс доставки
    /// </summary>
    public abstract class Delivery
    {
        public string Address;
        public DateTime OrderDate;
        public DateTime ShippedDate;
        public DateTime DeliveryDate;
        public DateTime DeliveredDate;
        public Delivery(Type type)
        {
            OrderDate = DateTime.Now;
            ShippedDate = DateTime.MinValue; // отметка пустого поля
            DeliveredDate = DateTime.MinValue;
            if (type == typeof(HomeDelivery))
                DeliveryDate = DateTime.Now.AddDays(5);
            else if (type == typeof(PickPointDelivery))
                DeliveryDate = DateTime.Now.AddDays(3);
            else
                DeliveryDate = DateTime.Now.AddDays(1);
        }
        public Delivery(Type type, string address) : this(type)
        {
            Address = address;
        }
    }
    /// <summary>
    /// Класс доставки на дом
    /// </summary>
    public class HomeDelivery : Delivery
    {
        public DateTime WishDate;
        public int DeliveryPrice;
        public HomeDelivery(string address) : base(typeof(HomeDelivery), address)
        {
            WishDate = DateTime.MinValue;
            DeliveryPrice = 500;
        }
        public HomeDelivery(string address, DateTime wishdate) : base(typeof(HomeDelivery), address)
        {
            WishDate = wishdate;
        }
        public override string ToString()
        {
            return
                "========= HomeDelivery =========\n" +
                $"Адрес доставки: {Address}\n" +
                $"Желаемое время доставки: {(WishDate == DateTime.MinValue ? "Как можно скорее" : WishDate)}\n" +
                $"Ожидаемое время доставки: {DeliveryDate}\n" +
                $"{(ShippedDate == DateTime.MinValue ? "Заказ не отправлен." : $"Заказ отправлен: {ShippedDate}\n")}" +
                $"{(DeliveredDate == DateTime.MinValue ? "Заказ еще не доставлен." : $"Заказ доставлен: {DeliveredDate}")}\n";
        }
    }
    /// <summary>
    /// Класс доставки до пункта выдачи
    /// </summary>
    class PickPointDelivery : Delivery
    {
        public PickPoint PickPoint { get; set; }
        public PickPointDelivery(PickPoint pickPoint) : base(typeof(PickPointDelivery))
        {
            PickPoint = pickPoint;
        }
        public override string ToString()
        {
            return
                "========= HomeDelivery =========\n" +
                $"Адрес доставки: {PickPoint.Address}\n" +
                $"Ожидаемое время доставки: {DeliveryDate}\n" +
                $"{(ShippedDate == DateTime.MinValue ? "Заказ не отправлен." : $"Заказ отправлен: {ShippedDate}")}\n" +
                $"{(DeliveredDate == DateTime.MinValue ? "Заказ еще не доставлен." : $"Заказ доставлен: {DeliveredDate}")}\n";
        }
    }
    /// <summary>
    /// Класс доставки в розничный магазин
    /// </summary>
    class ShopDelivery : Delivery
    {
        public Shop Shop { get; set; }
        public ShopDelivery(Shop shop) : base(typeof(ShopDelivery))
        {
            Shop = shop;
        }
        public override string ToString()
        {
            return
                "========= HomeDelivery =========\n" +
                $"Адрес доставки: {Shop.Address}\n" +
                $"Ожидаемое время доставки: {DeliveryDate}\n" +
                $"{(ShippedDate == DateTime.MinValue ? "Заказ не отправлен." : $"Заказ отправлен: {ShippedDate}")}\n" +
                $"{(DeliveredDate == DateTime.MinValue ? "Заказ еще не доставлен." : $"Заказ доставлен: {DeliveredDate}")}\n";
        }
    }
    /// <summary>
    /// Класс магазина
    /// </summary>
    public class Shop
    {
        public string Address { get; set; }
        public string WorkDays { get; set; }
        public string WorkTimeStart { get; set; }
        public string WorkTimeStop { get; set; }
        public override string ToString()
        {
            return $"{Address} | {WorkDays} с {WorkTimeStart} до {WorkTimeStop}";
        }
    }
    /// <summary>
    /// Класс пункта выдачи
    /// </summary>
    public class PickPoint : Shop
    {
        public string CompanyName { get; set; }
        public override string ToString()
        {
            return $"{CompanyName} - {Address} | {WorkDays} с {WorkTimeStart} до {WorkTimeStop}";
        }
    }
    /// <summary>
    /// Абстрактный класс-родитель для Manager и Customer
    /// </summary>
    public abstract class Person
    {
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
    }
    /// <summary>
    /// Класс менеджера
    /// </summary>
    public class Manager : Person
    {
        public int EmployeeId { get; private set; }
        public Manager(string Name, string Email, string Phone)
        {
            EmployeeId = new Random().Next();
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
        }
    }
    /// <summary>
    /// Класс заказчика
    /// </summary>
    public class Customer : Person
    {
        public int Id { get; private set; }
        private string _name;
        public override string Name
        {
            get { return _name; }
            set
            {
                if (value.Trim().Length > 0)
                    _name = value.Trim();
                else
                    Helper.Print("Имя не может быть пустым или состоять из пробелов.", ConsoleColor.Red);
            }
        }
        private string _email;
        public override string Email
        {
            get { return _email; }
            set
            {
                if (value.Contains("@"))
                    _email = value;
                else
                    Helper.Print("Неправильный email.", ConsoleColor.Red);
            }
        }
        private string _phone;
        public override string Phone
        {
            get { return _phone; }
            set
            {
                // https://qna.habr.com/q/84360?_ga=2.105457091.1509672255.1647934590-1661906621.1644194445
                if (Regex.IsMatch(value, @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$"))
                    _phone = value;
                else
                    Helper.Print("Неправильный номер телефона.", ConsoleColor.Red);
            }
        }
        public Customer()
        {
            Id = new Random().Next();

        entername: Helper.Print("Введите своё имя", ConsoleColor.Yellow);
            string name = Console.ReadLine();
            Name = name;
            if (Name != name) goto entername;

            enteremail: Helper.Print("Введите email", ConsoleColor.Yellow);
            string email = Console.ReadLine();
            Email = email;
            if (Email != email) goto enteremail;

            enterphone: Helper.Print("Введите номер телефона", ConsoleColor.Yellow);
            string phone = Console.ReadLine();
            Phone = phone;
            if (Phone != phone) goto enterphone;
        }
        public override string ToString()
        {
            return
                $"========= Customer =========\n" +
                $"ID: {Id}\n" +
                $"Пользователь: {Name}\n" +
                $"Почта: {Email}\n" +
                $"Номер телефона: {Phone}\n";
        }
    }
    /// <summary>
    /// Класс товара
    /// </summary>
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public uint Price { get; private set; }
        public uint Count;
        public byte Sale { get; private set; }
        public Product(string name, uint priceForOne, byte sale = 0, uint count = 1)
        {
            Id = new Random().Next(100, 999);
            Name = name;
            Sale = sale;
            Price = priceForOne;
            Count = count;
        }
        public override string ToString()
        {
            return $"[{Id}] {Name} x {Count} шт. | " +
                    $"{Price} * {Count} = {Price * Count} тг.";
        }
    }
    /// <summary>
    /// Класс заказа
    /// </summary>
    /// <typeparam name="TDelivery">Тип доставки</typeparam>
    public class Order<TDelivery> where TDelivery : Delivery
    {
        public TDelivery Delivery { get; private set; }
        public OrderState OrderState { get; private set; }
        public PaymentType PaymentType { get; private set; }
        public Guid Number { get; private set; }
        public List<Product> ItemsList { get; private set; }
        public uint AllPrice { get; private set; }
        public string Comment { get; private set; }
        public Manager Manager { get; private set; }
        public Customer Customer { get; private set; }

        public Order(List<Product> items)
        {
            ItemsList = items;
        }
        /// <summary>
        /// Оформление заказа
        /// </summary>
        /// <param name="delivery">Тип доставки</param>
        /// <param name="customer">Заказчик</param>
        /// <param name="comment">Комментарий</param>
        /// <param name="paymentType">Тип оплаты</param>
        public void PlaceOrder(TDelivery delivery, Customer customer, string comment, PaymentType paymentType)
        {
            Delivery = delivery;
            Customer = customer;
            Number = Guid.NewGuid();
            OrderState = OrderState.Created;
            Comment = comment;
            PaymentType = paymentType;
            Manager = Helper.managers[new Random().Next(0, Helper.managers.Count - 1)];
            Helper.Print(
                $"На ваш заказ назначен менеджер {Manager.Name}.\n" +
                $"Связаться можно по телефону {Manager.Phone}\n" +
                $"Либо по почте {Manager.Email}", ConsoleColor.Green);
        }
        /// <summary>
        /// Доступ к товарам по индексу, не обращаясь напрямую к свойству с товарами.
        /// </summary>
        /// <param name="index">Индекс товара</param>
        /// <returns>Найденый товар</returns>
        public Product this[int index]
        {
            get
            {
                if (index >= 0 && index < ItemsList.Count)
                {
                    return ItemsList[index];
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// Изменение состояние заказа. Должен применяться закрепленными менеджерами.
        /// </summary>
        /// <param name="state">Состояние заказа</param>
        public void ChangeOrderState(OrderState state)
        {
            if (state == OrderState.OnDelivery)
            {
                Delivery.ShippedDate = DateTime.Now;
            }
            if (state == OrderState.Delivered)
            {
                Delivery.DeliveredDate = DateTime.Now;
            }
            OrderState = state;
        }
        /// <summary>
        /// Добавление товара в список товаров.
        /// </summary>
        /// <param name="item">Объект товара</param>
        public void AddItem(Product item)
        {
            ItemsList.Add(item);
            AllPrice += item.Price;
            Helper.Print($"Товар {item.Name} добавлен.", ConsoleColor.Green);
        }
        /// <summary>
        /// Удаление товара по объекту.
        /// </summary>
        /// <param name="item">Объект для удаления</param>
        public void RemoveItem(Product item)
        {
            if (ItemsList.Contains(item))
            {
                AllPrice -= item.Price;
                ItemsList.Remove(item);
                Helper.Print($"Товар {item.Name} удален.", ConsoleColor.Red);
            }
            else
                Helper.Print($"Товар {item.Name} не найден в вашей корзине.", ConsoleColor.Red);
        }
        /// <summary>
        /// Удаление товара по индексу.
        /// </summary>
        /// <param name="index">Индекс товара</param>
        public void RemoveItem(int index)
        {
            if (index >= 0 && index < ItemsList.Count)
            {
                AllPrice -= ItemsList[index].Price;
                Helper.Print($"Товар {ItemsList[index].Name} удален.", ConsoleColor.Red);
                ItemsList.RemoveAt(index);
            }
            else
                Helper.Print($"Товар не найден.", ConsoleColor.Red);
        }
        /// <summary>
        /// Статически метод. Печать списка товаров в заказе.
        /// </summary>
        /// <param name="products">Список товаров для печати.</param>
        public static void PrintCart(List<Product> products)
        {
            if (products.Count > 0)
            {
                Helper.Print("У вас в корзине:", ConsoleColor.DarkYellow);
                uint AllPrice = 0;
                uint AllPriceWithSale = 0;
                foreach (Product product in products)
                {
                    AllPrice += product.Price;
                    if (product.Sale > 0)
                        AllPriceWithSale += product.Price / 100 * product.Sale;
                    Helper.Print(product.ToString(), ConsoleColor.Yellow);
                }
                Helper.Print($"\nИтого: {AllPrice} тг.\n", ConsoleColor.Cyan);
                if (AllPriceWithSale > 0)
                {
                    Helper.Print($"Скидка: {AllPriceWithSale} тг.\n", ConsoleColor.Cyan);
                    Helper.Print($"Итого с учетом скидок: {AllPrice - AllPriceWithSale} тг.\n", ConsoleColor.Cyan);
                }
            }
            else
                Helper.Print($"Корзина пуста.", ConsoleColor.Red);
        }
        /// <summary>
        /// Печать в терминал информации о заказчике, идентификаторе заказа, его статусе и информации о доставке.
        /// В случае если заказ уже создан, печатается и его состав.
        /// </summary>
        public void CheckOrder()
        {
            PrintInfo();
            if (OrderState != OrderState.WaitingToCreate)
                PrintCart(ItemsList);
        }
        /// <summary>
        /// Печать в терминал информации о заказчике, идентификаторе заказа, его статусе и информации о доставке.
        /// </summary>
        public void PrintInfo()
        {
            Helper.Print(Customer.ToString(), ConsoleColor.Cyan);
            Helper.Print($"Идентификатор заказа: {Number.ToString().ToUpper()}", ConsoleColor.Cyan);
            Helper.Print($"Статус заказа: {OrderState}", ConsoleColor.Cyan);
            Helper.Print(Delivery.ToString(), ConsoleColor.DarkCyan);
        }
    }
}
