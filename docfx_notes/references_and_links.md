Links and Cross References
==========
> [!WARNING]
> Это краткая версия страницы [DocFX Links and Cross References](https://dotnet.github.io/docfx/tutorial/links_and_cross_references.html)

###Основное
В DocFX используется синтакс гиперссылок `Markdown`.
Пример:
```
[bing](http://www.bing.com)
```
В DocFX используется шаблон [Glob](https://github.com/vicancy/Glob).  
Также DocFX предоставляет возможность использования символов `~` и `..`, которые представляют собой указатель на корень проекта - область проекта где находится `docfx.json`.
Пример:
```
[file1](~/file1.md)

[file1](../file1.md)
```
Данный пример представляет собой *относительный путь*, т.е. путь к файлам `md` и `yml` , которые затем будут преобразованы в `html`, но также можно использовать *абсолютный путь*:
```
[file2](/subfolder/file2.html)
```

###Ссылка по UID
`uid` - это уникальный идентификатор каждого объекта в проекте DocFX.

В данном случае синтаксис гиперссылки будет:
```
[link_text](xref:uid_of_another_file)
```
Также существует краткая форма гиперссылки на объекты с `uid`:
```
@uid_to_another_file
```