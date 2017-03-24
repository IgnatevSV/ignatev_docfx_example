Requirements and Issues
=======================

Requirements
------------
1. Visual Studio 2015 или Microsoft Build Tools 2015.
2. Git.

Issues
------
1. На 32-битных системах Windows создание билда работает некорректно.

2. Некорректно работает с Visual Studio Community 2017.

3. В проекте обязательно должны быть указаны пространства имен(namespace) для классов, которые должны быть отображены в API Documents.

4. Для корректного отображения классов в API Documents в `docfx.json/src/files` разрешение файлов должно быть `.sln`.