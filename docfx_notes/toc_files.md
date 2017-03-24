Файлы Table-Of-Content (TOC)
=============================
> [!WARNING]
> Это краткая версия страницы [DocFX TOC Files](https://dotnet.github.io/docfx/tutorial/intro_toc.html)

##Основное
Файлы **TOC** должны именоваться как `toc.md` или `toc.yml`.
> [!NOTE]
>В оф.документации указано, что имя файла `toc.md` или `toc.yml` не чувствителен к регистру.
>
>Однако по факту имя файла `toc.md` или `toc.yml` должно быть в **нижнем регистре**, иначе работа может быть некорректной.

##Примеры
Пример `toc.md`:

```
# [Header1](href)
## [Header1.1](href)
# Header2
## [Header2.1](href)
### [Header2.1.1](href)
## [Header2.2](href)
# @UidForAnArticle
```

Пример использования `toc.md`:  
+ DocFX Notes

Пример `toc.yml`:
```
- name: Topic1
  href: Topic1.md
- name: Topic2
  href: Topic2.md
  items:
    - name: Topic2_1
      href: Topic2_1.md
```

Пример использования `toc.yml`:  
+ Dialogues System Description

> [!CAUTION]
> Имена свойств в `toc.yml` чувствительны к регистру!