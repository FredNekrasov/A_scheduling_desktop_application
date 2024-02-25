# Scheduling application.

Scheduling application - desktop C# WPF приложение для составления расписания с использованием [веб-сервиса/RESTful API](https://github.com/FredNekrasov/service_for_storing_schedules).

Прежде чем начать работу с приложением, пользователю необходимо пройти простую капчу.

Это приложение предоставляет удобный интерфейс для работы с данными расписания в учебном заведении. Пользователи могут добавлять, изменять и удалять информацию о:
- семестрах;
- неделях;
- предметах;
- типах аудиторий;
- кабинетах;
- преподавателях;
- группах;
- парах;
- днях.

Важно отметить, что информацию о днях можно только добавлять и удалять, не редактировать. Приложение обеспечивает проверку вводимой информации на корректность, что помогает избежать ошибок при составлении расписания. Благодаря использованию RESTful API, приложение обладает гибкостью и может обновлять данные в реальном времени, отображая актуальное расписание. С помощью этого приложения вы сможете эффективно организовать рабочий процесс по составлению расписания, упростить управление данными и повысить точность информации. А также приложение обеспечит вас удобным и интуитивно понятным интерфейсом для работы с расписанием.

Пользователям также доступна возможность экспорта данных в Excel файл для удобного сохранения и отображения информации. Необходимо иметь в виду, что процесс экспорта данных может иметь свои особенности и нюансы, связанные с форматированием и структурой Excel файла.

Важно отметить, что данное решение является демонстрационным примером и не предполагает полностью верное или законченное решение для всех случаев использования. Реальное приложение требует более глубокого анализа и обработки различных случаев взаимодействия.

### Использованные источники
В данном проекте использованы следующие библиотеки:
1. Microsoft.AspNet.WebApi.Client: для взаимодействия с RESTful API и обмена данными.
2. Newtonsoft.Json: для работы с JSON-форматом данных и их сериализации/десериализации.
3. Microsoft.Office.Interop.Excel: для создания и обработки Excel файлов в составе приложения.
4. MahApps.Metro.IconPacks.Material: для использования красочных иконок и улучшения пользовательского интерфейса.

<details><summary><h3><b>Изображения</b></h3></summary>

### Капча
![image](https://github.com/FredNekrasov/A_scheduling_desktop_application/assets/152185797/ade6c56a-c74f-4e40-8628-e33b5419a739)
![image](https://github.com/FredNekrasov/A_scheduling_desktop_application/assets/152185797/ce23f020-8424-4ec4-b8a7-14215717dafc)

### Отображение списка данных
![image](https://github.com/FredNekrasov/A_scheduling_desktop_application/assets/152185797/adfccda9-db0c-44cc-8b6a-e0178279fc24)
![image](https://github.com/FredNekrasov/A_scheduling_desktop_application/assets/152185797/7bb8061a-ddac-4c79-ad01-d695bb677b9e)
![image](https://github.com/FredNekrasov/A_scheduling_desktop_application/assets/152185797/2072d247-09dc-4779-a5b3-f8c8c7dabb9c)

### Создание excel файла по нажатию на кнопку "Excel файл"
![image](https://github.com/FredNekrasov/A_scheduling_desktop_application/assets/152185797/1f3f607e-9617-4211-beb4-ac1a2d9d8bf4)

### Добавление новой пары
![image](https://github.com/FredNekrasov/A_scheduling_desktop_application/assets/152185797/7bb8061a-ddac-4c79-ad01-d695bb677b9e)
![image](https://github.com/FredNekrasov/A_scheduling_desktop_application/assets/152185797/f4e1ce10-f0cd-4c8e-89f5-5d44e5f8e4dc)
![image](https://github.com/FredNekrasov/A_scheduling_desktop_application/assets/152185797/b76def9e-36b9-4a65-af68-f0142b3bb9ad)

### Проверка данных на корректность при добавлении новой аудитории.
![image](https://github.com/FredNekrasov/A_scheduling_desktop_application/assets/152185797/78ddbfcc-4504-4566-9ee0-0d2b32a66d33)

### Изменение данных пользователя
![image](https://github.com/FredNekrasov/A_scheduling_desktop_application/assets/152185797/adfccda9-db0c-44cc-8b6a-e0178279fc24)
![image](https://github.com/FredNekrasov/A_scheduling_desktop_application/assets/152185797/3ebbbfec-2d3e-4f7d-bc6a-24b5e6725f70)
![image](https://github.com/FredNekrasov/A_scheduling_desktop_application/assets/152185797/91a76303-3d8c-496d-9d29-ba95d5bce553)
![image](https://github.com/FredNekrasov/A_scheduling_desktop_application/assets/152185797/e69a29c4-e966-4865-98cc-9faf258a7610)

### Удаление информации о дне
![image](https://github.com/FredNekrasov/A_scheduling_desktop_application/assets/152185797/8af2f113-2408-4206-bde1-7f911bf9df83)
![image](https://github.com/FredNekrasov/A_scheduling_desktop_application/assets/152185797/f090ee94-b8c6-4a0f-a6ee-1bb50e616db4)
</details>

<details><summary><h3><b>Тесты:</b></h3></summary>

1. **Общая функциональность:**
   - [X] Загрузка приложения без ошибок
   - [X] Наличие всех основных компонентов интерфейса
   - [X] Навигация между различными разделами приложения
   - [X] Возможность добавления, изменения и удаления информации об объектах базы данных

2. **Проверка информации на корректность:**
   - [X] Валидация вводимых данных на стороне клиента
   - [X] Обработка ошибок ввода данных

3. **Взаимодействие с RESTful API:**
   - [X] Проверка корректности отправки запросов к API
   - [ ] Обработка ответов API (успешные и ошибочные)

4. **Экспорт данных в Excel:**
   - [X] Возможность экспорта данных в Excel file
   - [X] Проверка корректности данных в экспортированном Excel файле

5. **Тестирование удаления данных:**
   - [X] Проверка корректности удаления записей из различных сущностей, у которых нет связей в других таблицах.
   - [X] Проверка удаления записи, у которых есть связи в других таблицах.
   - [X] Убедиться, что запись осталась нетронутой.

6. **Тестирование графического интерфейса:**
   - [X] Проверка отображения данных
   - [X] Проверка работы элементов управления (кнопки, поля ввода, выпадающие списки и т. д.)
   - [ ] Адаптивность интерфейса под различные разрешения экранов

7. **Тестирование производительности:**
   - [ ] Проверка скорости отклика приложения при работе с большим объемом данных
   - [ ] Тестирование при работе с медленным интернет-соединением

</details>
