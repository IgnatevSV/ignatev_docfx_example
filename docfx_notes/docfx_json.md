docfx.json
==========
> [!WARNING]
> Это краткая версия страницы [DocFX User Manual](https://dotnet.github.io/docfx/tutorial/docfx.exe_user_manual.html)

Структура `docfx.json` представляет собой пару ключ-значение.

###Свойства для `metadata`

Свойство                 | Описание
-------------------------|-----------------------------
src                      | Определяет исходные проекты, для которых необходимо сгенерировать `metadata` файлы.
dest                     | Определяет папки для вывода сгенерированных `metadata` файлов.
shouldSkipMarkup         | `Bool` значение для отключения рендеринга triple-slash-комментариев в исходном коде как markdown.
filter                   | Определяет фильтр для конфигурационных файлов.

Примеры:
```json
{
  "metadata": [
    {
      "src": [
        {
          "files": ["**/*.csproj"],
          "exclude": [ "**/bin/**", "**/obj/**" ], 
          "src": "../src"
        }
      ],
      "dest": "obj/docfx/api/dotnet",
      "shouldSkipMarkup": true
    },
    {
      "src": [
        {
          "files": ["**/*.js"],
          "src": "../src"
        }
      ],
      "dest": "obj/docfx/api/js",
      "useCompatibilityFileName": true
    }
  ]
}

```

###Свойства для `build`

Свойство                 | Описание
-------------------------|-----------------------------
content                  | Содержит все файлы, которые необходимы для генерации документации.
resource                 | Содержит все ресурсные файлы, такие как, например, изображения.
overwrite                | Содержит все файлы, которые предназначены для перезаписи существующих файлов `yml`.
globalMetadata           | Содержит метаданные, которые будут применены к каждому файлу в формате ключ-значение.
fileMetadata             | Содержит метаданные, которые будут применены к определенным файлам.
globalMetadataFiles      | Определяет список файлов JSON которые содержат настройки globalMetadata.
fileMetadataFiles        | Определяет список файлов JSON которые содержат настройки fileMetadata.
template                 | Шаблон, который будет применен к каждому файлу в документации.
theme                    | Тема, которая будет применена к документации. Тема используется для изменения стиля, сгенерированного шаблоном.
xref                     | Определяет ссылки xrefmap, которые используются для файлов `content`. На данный момент подерживает следующие форматы: http, https, ftp, file.

Примеры `template`:

```json
{
    "build" : 
    {
      ...
      "template": "custom",
      ...
    }
  ... 
}
```
```json
{
    "build" : 
    {
      ...
      "template": ["default", "X:/template/custom"],
      ...
    }
  ... 
}
```

Примеры:
```json
{
  "build": {
    "content":
      [
        {
          "files": ["**/*.yml"],
          "src": "obj/docfx"
        },
        {
          "files": ["tutorial/**/*.md", "spec/**/*.md", "spec/**/toc.yml"]
        },
        {
          "files": ["toc.yml"]
        }
      ],
    "resource": [
        {
          "files": ["spec/images/**"]
        }
    ],
    "overwrite": "apispec/*.md",
    "externalReference": [
    ],
    "globalMetadata": {
      "_appTitle": "DocFX website"
    },
    "dest": "_site",
    "template": "default"
  }
}
```

#### Зарезервированные имена метаданных

Metadata Name         | Type    | Description
----------------------|---------|---------------------------
_appTitle             | string  | Текст заголовка каждой страницы.
_appFooter            | string  | Текст нижнего колонтикула.
_appLogoPath          | string  | Путь к изображению логотипа каждой страницы.
_appFaviconPath       | string  | Путь к изображению иконки каждой страницы..
_enableSearch         | bool    | Включает поиск по всему вебсайту.
_enableNewTab         | bool    | Открывает ли новую вкладку по переходу по ссылке.
_disableNavbar        | bool    | Отключает navbar вверху страницы.
_disableBreadcrumb    | bool    | Отключает breadcrumb вверху странцы.
_disableToc           | bool    | Отключает table of contents слева на странице.
_disableAffix         | bool    | Отключает affix bar справа на странице.
_disableContribution  | bool    | Отключает кнопки `View Source` и `Improve this Doc` справа на странице.
_gitContribute        | object  | Настройка кнопки `Improve this Doc`. В `repo` указывается ссылка на репозиторий. В `branch` указывается ветка(branch) репозитория. В `path` указывается путь для перезаписи файлов.
_gitUrlPattern        | string  | Шаблон ссылки на репозиторий для генерации ссылок на кнопка `View Source` и `Improve this Doc`. На текущий момент поддерживает `github` и `vso` currently. Если не указано, то DocFX попытается использовать шаблон из имени домена ссылки на git.


Cпособs установки метаданных для файлов:

1. `global metadata` устанавливает метаданные для каждого файла.
2. `file metadata` устанавливает метаданные для файлов, которые совпадают по заданному шаблону.
3. `YAML header` устанавливает метаданные для заданного файла.

Примеры:

+ Пример `globalMetadata` 
    ```json
    {
        "_appTitle": "DocFX website",
        "_enableSearch": "true"
    }
    ```

+ Пример `fileMetadata`
    ```json
    {
        "priority": {
            "**.md": 2.5,
            "spec/**.md": 3
        },
        "keywords": {
            "obj/docfx/**": ["API", "Reference"],
            "spec/**.md": ["Spec", "Conceptual"]
        }
    }
    ```

+ Пример использования `globalMetadataFiles` в `docfx.json`
    ```json
    ...
    "globalMetadataFiles": ["global1.json", "global2.json"],
    ...
    ```

+ Пример использования `--globalMetadataFiles` при создании билда через коммандную строку
    ```
    docfx build --globalMetadataFiles global1.json,global2.json
    ```

+ Пример использования `fileMetadataFiles` в `docfx.json`
    ```json
    ...
    "fileMetadataFiles": ["file1.json", "file2.json"],
    ...
    ```

+ Пример использования `--fileMetadataFiles` при создании билда через коммандную строку
    ```
    docfx build --fileMetadataFiles file1.json,file2.json
    ```

+ Приоритет global metadata: 
    1. global metadata из файла docfx config
    2. global metadata из global metadata
    3. global metadata из командной строки

+ Приоритет file metadata: 
    1. file metadata из файла docfx config
    2. file metadata из файла file metadata

### Формат File Mapping

Property Name      | Description
-------------------|----------------------------- 
files              | **REQUIRED**. Файл или массив файлов. Поддерживается шаблон `glob`.
exclude            | Файл или массив файлов, которые должны быть исключены. Поддерживается шаблон `glob`.
src                | Каталог источника.
dest               | Каталог для сгенерированных файлов.
version            | Версия текущего файла.
caseSensitive      | **TOBEIMPLEMENTED**. Чувствительность к регистру шаблона `glob`. Значение по умолчанию - `false`.
supportBackslash   | **TOBEIMPLEMENTED**. Если значение - `true`, то символ `\` будет использоваться как разделитель пути файлов. Значение по умолчанию - `false`.
escape             | **TOBEIMPLEMENTED**. Если значение - `true`, то символ `\` будет использоваться как escape-символ, т.е. `\{\}.txt` будет равносильно `{}.txt`. Значение по умолчанию - `false`.

Пример:
```json
"key": [
  {"files": ["file1", "file2"], "dest": "dest1"},
  {"files": "file3", "dest": "dest2"},
  {"files": ["file4", "file5"], "exclude": ["file5"], "src": "folder1"},
  {"files": "Example.yml", "src": "v1.0", "dest":"v1.0/api", "version": "v1.0"},
  {"files": "Example.yml", "src": "v2.0", "dest":"v2.0/api", "version": "v2.0"}
]
```



### Шаблон Glob
`DocFX` использует [Glob](https://github.com/vicancy/Glob) для поддержки шаблона *glob* в пути к файлам.

1. `*` соответствует любому числу символов кроме `/`
2. `?` соответствует одному символу кроме `/`
3. `**` соответствует любому числу символов включая `/`, но только для одного объекта указанного в пути
4. `{}` разрешает разделенный запятыми список выражений **OR**