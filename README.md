<h1 align="center">Программа "Бюро обмена квартир Винзили"</h1>

[<img src='https://cdn.jsdelivr.net/npm/simple-icons@3.0.1/icons/github.svg' alt='github' height='40'>](https://github.com/sizze1veG)  [<img src='https://cdn.jsdelivr.net/npm/simple-icons@3.0.1/icons/instagram.svg' alt='instagram' height='40'>](https://www.instagram.com/sizze1veG/)  [<img src='https://cdn.jsdelivr.net/npm/simple-icons@3.0.1/icons/icloud.svg' alt='website' height='40'>](https://vk.com/sizze1veg)  

<h2>Задание</h2>
Картотека в бюро обмена квартир организована в виде линейного списка. Сведения о каждой квартире включают:

- Количество комнат;
-	Этаж;
-	Площадь;
- Адрес;

Написать программу, которая обеспечивает:

-	Начальное формирование картотеки;
-	Ввод заявки на обмен;
-	Поиск в картотеке подходящего варианта: при равенстве количества комнат и этажа и различии площадей в пределах 10% соответствующая картотека выводится и удаляется из списка, в противном случае поступившая заявка включается в список;
-	Вывод всего списка.

Программа должна обеспечивать диалог с помощью меню и контроль ошибок при вводе.

<h2>Интерфейс</h2>

- Главное окно программы

<picture>
  <img src="https://github.com/sizze1veG/ApartmentExchangeBureau/blob/main/screenshots/Screenshot_1.png">
</picture>

На главном окне программы находится полный список квартир и поля для добавления новых квартир.

- Добавление квартиры

Чтобы ввести новую квартиру нужно заполнить поля количества комнат, этажа, площади и адреса новой квартиры. 
Количество комнат не может быть больше 10. Этаж не может быть больше 40. Площадь представлена в виде вещественного числа. 
Она не может превосходить 300. Если все данные введены верно, то программа начинает поиск подходящих квартир. 
Если она находит квартиру, которая совпадает по количеству комнат, этажу с введённой и разница между площадями не превосходит 10%, 
то программа вносит в новый список эту квартиру.

Если подходящих квартир не нашлось, то она просто добавляется в общую базу.

<picture>
  <img src="https://github.com/sizze1veG/ApartmentExchangeBureau/blob/main/screenshots/Screenshot_2.png">
</picture>

- Обмен квартиры

<picture>
  <img src="https://github.com/sizze1veG/ApartmentExchangeBureau/blob/main/screenshots/Screenshot_3.png">
</picture>

При открытии окна подходящих кваритр для обмена, заполняется таблица списком подходящих квартир. Далее можно выбрать квартиру, которую хотим. 
После выбора нужно нажать на кнопку «Создать заявку». Программа удалит выбранную квартиру из базы данных и сформирует pdf файл с заявкой на обмен. 

Если ни одна из квартир не подходит, то можно нажать на кнопку «Отмена» и вернутся на первую форму.

<picture>
  <img src="https://github.com/sizze1veG/ApartmentExchangeBureau/blob/main/screenshots/Screenshot_4.png">
</picture>

Pdf файл генерируется с помощью библиотеки iTextSharp.

<picture>
  <img src="https://github.com/sizze1veG/ApartmentExchangeBureau/blob/main/screenshots/Screenshot_5.png">
</picture>
