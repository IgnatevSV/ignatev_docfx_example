Overwrite Files
==========
> [!WARNING]
> Это краткая версия страницы [DocFX Overwrite Files](https://dotnet.github.io/docfx/tutorial/intro_overwrite_files.html)

###Основное
Перезаписывающие файлы указываются в [docfx.json](docfx_json.md).
>[!WARNING]
>В перезаписывающем файле обязательно должен быть указан `uid` - уникальный идентификатор объекта(в данном случае перезаписываемого объекта) в проекте DocFX.  
Перезаписывающие файлы могут быть в формате `Markdown` или `YAML`.

Пример в формате `Markdown`:
```
---
uid: MyNamespace.MyClass.MyFunction
remarks: Это перезаписанная ремарка.
---
```
Пример в формате `YAML`:
```
uid: MyNamespace.MyClass.MyFunction
remarks: Это перезаписанная ремарка.
```

Пример использования:  
+ open_dialogue_example.md @Other.UsingExamples.OpenDialogueExample.OpenDialogue

### Модели данных в DocFX

Key                     | Type                       | Overwrite behavior
----------------------- | -------------------------- | ------------------
**uid**                 | uid                        | Merge key.
assemblies              | string[]                   | Ignore.
attributes              | [Attribute](#attribute)[]  | Ignore.
children                | uid[]                      | Ignore.
documentation           | [Source](#source)          | Merge.
example                 | string[]                   | Replace.
exceptions              | [Exception](#exception)[]  | Merge keyed list.
fullName                | string                     | Replace.
fullName.<lang>         | string                     | Replace.
id                      | string                     | Replace.
implements              | uid[]                      | Ignore.
inheritance             | uid[]                      | Ignore.
inheritedMembers        | uid[]                      | Ignore.
isEii                   | boolean                    | Replace.
isExtensionMethod       | boolean                    | Replace.
langs                   | string[]                   | Replace.
modifiers.<lang>        | string[]                   | Ignore.
name                    | string                     | Replace.
name.<lang>             | string                     | Replace.
namespace               | uid                        | Replace.
overridden              | uid                        | Replace.
parent                  | uid                        | Replace.
platform                | string[]                   | Replace.
*remarks*               | markdown                   | Replace.
see                     | [LinkInfo](#linkinfo)[]    | Merge keyed list.
seealso                 | [LinkInfo](#linkinfo)[]    | Merge keyed list.
source                  | [Source](#source)          | Merge.
*syntax*                | [Syntax](#syntax)          | Merge.
*summary*               | markdown                   | Replace.
type                    | string                     | Replace.

**Source**

Property                | Type                       | Overwrite behavior
----------------------- | -------------------------- | ------------------
base                    | string                     | Replace.
content                 | string                     | Replace.
endLine                 | integer                    | Replace.
id                      | string                     | Replace.
isExternal              | boolean                    | Replace.
href                    | string                     | Replace.
path                    | string                     | Replace.
remote                  | [GitSource](#gitsource)    | Merge.
startLine               | integer                    | Replace.

**GitSource**

Property                | Type                       | Overwrite behavior
----------------------- | -------------------------- | ------------------
path                    | string                     | Replace.
branch                  | string                     | Replace.
repo                    | url                        | Replace.
commit                  | [Commit](#commit)          | Merge.
key                     | string                     | Replace.

**Commit**

Property                | Type                       | Overwrite behavior
----------------------- | -------------------------- | ------------------
committer               | [User](#user)              | Replace.
author                  | [User](#user)              | Replace.
id                      | string                     | Replace.
message                 | string                     | Replace.

**User**

Property                | Type                       | Overwrite behavior
----------------------- | -------------------------- | ------------------
name                    | string                     | Replace.
email                   | string                     | Replace.
date                    | datetime                   | Replace.

**Exception**

Property                | Type                       | Overwrite behavior
----------------------- | -------------------------- | ------------------
**type**                | uid                        | Merge key.
*description*           | markdown                   | Replace.
commentId               | string                     | Ignore.

**LinkInfo**

Property                | Type                       | Overwrite behavior
----------------------- | -------------------------- | ------------------
**linkId**              | uid or href                | Merge key.
*altText*               | markdown                   | Replace.
commentId               | string                     | Ignore.
linkType                | enum(`CRef` or `HRef`)     | Ignore.

**Syntax**

Property                | Type                       | Overwrite behavior
----------------------- | -------------------------- | ------------------
content                 | string                     | Replace.
content.<lang>          | string                     | Replace.
parameters              | [Parameter](#parameter)[]  | Merge keyed list.
typeParameters          | [Parameter](#parameter)[]  | Merge keyed list.
return                  | [Parameter](#parameter)    | Merge.

**Parameter**

Property                | Type                       | Overwrite behavior
----------------------- | -------------------------- | ------------------
**id**                  | string                     | Merge key.
*description*           | markdown                   | Replace.
attributes              | [Attribute](#attribute)[]  | Ignore.
type                    | uid                        | Replace.

**Attribute**

Property                | Type                              | Overwrite behavior
----------------------- | --------------------------------- | ------------------
arguments               | [Argument](#argument)[]           | Ignore.
ctor                    | uid                               | Ignore.
namedArguments          | [NamedArgument](#namedargument)[] | Ignore.
type                    | uid                               | Ignore.

**Argument**

Property                | Type                      | Overwrite behavior
----------------------- | ------------------------- | ------------------
type                    | uid                       | Ignore.
value                   | object                    | Ignore.

**NamedArgument**

Property                | Type                      | Overwrite behavior
----------------------- | ------------------------- | ------------------
name                    | string                    | Ignore.
type                    | string                    | Ignore.
value                   | object                    | Ignore.


#### REST API model
Key | Type | Overwrite behavior
--- | --- | ---
*uid* | string | Key
*children* | [REST API item model](#rest-api-item-model) | Overwrite when *uid* of the item model matches
*summary* | string | Overwrite
*description* | string | Overwrite

#### Conceptual model
Key | Type | Overwrite behavior
--- | --- | ---
*title* | string | Overwrite
*rawTitle* | string | Overwrite
*conceptual* | string | Overwrite