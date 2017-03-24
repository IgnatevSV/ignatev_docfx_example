Quickstart
==========
> [!WARNING]
> Это краткая версия страницы [DocFX Quickstart](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html)

###Использование через командную строку

> [!Note]
> Перед тем как использовать DocFX убедитесь, что установлен [Visual Studio 2015](https://www.visualstudio.com/vs/) или же [Microsoft Build Tools 2015](https://www.microsoft.com/en-us/download/details.aspx?id=48159).

*Step1.* Скачать и распаковать *docfx.zip* из https://github.com/dotnet/docfx/releases

*Step2.* Инициализировать шаблон через командную строку:
```
docfx init
```
Или:
```
docfx init -q
```
Для создания шаблона по умолчанию.

Данная команда сгенерирует шаблон `docfx_project` в папке с DocFX.

*Step3.* Создание билда и запуск сайта

Создание билда:
```
docfx docfx_project\docfx.json
```
Запуск:
```
docfx serve docfx_project\_site
```

Или же:
```
docfx docfx_project\docfx.json --serve
```
Для создания билда и немедленного запуска.