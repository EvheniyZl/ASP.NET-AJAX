Розробити конвеєр який буде аналізувати вхідні запити від клієнта і виконувати наступну логіку:
1.	Якщо клієнт нічого не передав в параметрах запиту буде повернуто привітання «Привіт користувач NET 6.0”
2.	Якщо запит буде такий /info або такий 
/info?name=ivan&age=33 буде повернуто інформацію щодо самого запиту:
Host = localhost:port
Path = info
QueryString = name=ivan&age=33
3.	 Якщо запит буде такий /time  буде повернуто поточну дату та час.
4.	Якщо запит буде такий /key  буде повернуто значення відповідного ключа із файлу appsettings.json.