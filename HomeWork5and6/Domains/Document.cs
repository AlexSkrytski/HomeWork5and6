using System.Text.Json.Serialization;

namespace HomeWork5and6.Domains
{

    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(ContractDocument), typeDiscriminator: "contract")]
    [JsonDerivedType(typeof(InvoiceDocument), typeDiscriminator: "invoice")]

    public abstract class Document
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}

//    Эти атрибуты нужны для полиморфной сериализации и десериализации JSON в .NET (начиная с .NET 7).
//    Они решают главную проблему: как передать абстрактный класс в API, чтобы сервер понял,
//    какой именно дочерний объект (класс-наследник) ему прислали.
//    Вот для чего конкретно служит каждая строка:
//    1. [JsonPolymorphic] — Включает режим полиморфизмаЭтот атрибут говорит JSON-сериализатору,
//    что у данного класса есть наследники.TypeDiscriminatorPropertyName = "type": задает имя
//    специального служебного поля в JSON (в данном случае "type"), 
//    по которому система будет определять конкретный класс.
//    2. [JsonDerivedType] — Регистрирует классы-наследникиЭти атрибуты связывают конкретные
//    C#-классы со строковыми метками (дискриминаторами) в JSON.[JsonDerivedType(typeof(ContractDocument),
//    typeDiscriminator: "contract")]Если в JSON-документе поле "type" имеет значение "contract",
//    создай объект ContractDocument.[JsonDerivedType(typeof(InvoiceDocument), 
//    typeDiscriminator: "invoice")]Если в JSON-документе поле "type" имеет значение "invoice", 
//    создай объект InvoiceDocument.

//  Как это работает на практике?Когда клиент отправляет POST-запрос, ваш метод в контроллере принимает 
//абстрактный тип:csharppublic IActionResult Create([FromBody] Document doc) { ... }
//Благодаря этим атрибутам, парсер смотрит на JSON:
//json
//{
//  "type": "invoice", 
//  "Amount": 500
//}
//. Видит "type": "invoice", автоматически конвертирует его в полноценный объект 
// класса InvoiceDocument и передает в контроллер. Без этих атрибутов код выдал бы ошибку, 
// так как создать экземпляр абстрактного класса Document физически невозможно.