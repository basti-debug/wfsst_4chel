<h1>Dokumentation WFSST </h1>

[TOC]


# 2022-09-15 Einführung, Markdown, Versionsverwaltung

- [x] Beurteilung
	- [x] anhand Projekt
	- [x] (MA) aktive Mitarbeit -> +/-
	- [x] (MA) Hausübung, SMÜ
	- [x] Note -> 50% MA, 50% Projekt

>MA und Projekt müssen positiv sein

## Markdown
siehe https://www.markdownguide.org/
### Aufzählungen
~~~
- item 1
- item 2
~~~

- item 1
- item 2

### Nummerierungen
~~~
1. item 1
2. item 2
~~~

1. item 1
1. item 2
1. item 3

### Überschriften
~~~
# Ebene 1
## Ebene 2
~~~

### Textformatierungen
~~~
Franz *jagt* im **komplett** verwahr_losten_ Taxi
~~~
Franz *jagt* im **komplett** verwahr_losten_ Taxi

### Blockquote
Für Zitate, Definitionen, ...
~~~
> Zitat
~~~

> Zitat

### Code im Text
Es ist auch möglich, im Text `Console.WriteLine("Hello")` anzugeben

### Hypertext im Markdown Code
~~~html
<!-- Kommentar -->
<h2>Überschrift 2</h2>
~~~

Es ist auch möglich, im markdown Hypertext für bestimmte Ausnahmefälle anzugeben.

### Abgrenzungslinine
---
Franz ...

---

### Einfügen von Abbildungen

![[WIN_20220915_10_11_29_Pro.jpg]]

### Syntaxhighlighting von Code
~~~c
// Ein HelloWorld in c 
printf("Hello world.");
~~~

~~~python
#Ein HelloWorld in python
print("Hello world.");
~~~
~~~cs
//Ein HelloWorld in c 
Console.WriteLine("Hello world.");
~~~

### Tabellen

| Datum      | Text       |
| ---------- | ---------- |
| 2022-09-15 | markdown   |
| 2022-09-22 | **gitlab** |
| 😄         | 👎         |

### Diagramme
https://mermaid-is.github.io

~~~mermaid
flowchart TD
	Start --> Stop
	Aufstehen ---> Kaffee
	Aufstehen --> Start
~~~


# Beispiele für Versionsverwaltungen
- git
- svn ... subversion
- mercurial
- cvs
- teamfoundation

# Plattformen
- github.com -> MS
- gitlab.com -> selber hosten möglich -> freeware für grundlegende Funktionen
- bitbucket
- ...

# Grundlegende Bash Befehle
| Befehl              | Beispiel        | Erklärung                                                                                                      |
| ------------------- | --------------- | -------------------------------------------------------------------------------------------------------------- |
| prompt              |                 | Hinweis, dass jetzt ein Befehl eingegeben werden kann, kann unterschiedlich ausschauen und lässt sich anpassen |
| ls                  |                 | gibt Inhalt des aktuellen VZ aus                                                                               |
| ~                   |                 | Homeverzeichnis                                                                                                |
| pwd                 |                 | print working directory, gibt den Pfad des aktuellen VZ aus                                                    |
| `cd <pfad>`         | `cd </c/temp>`  | change directory                                                                                               |
| `mkdir <pfad>`      | `mkrid <repos>` | Bsp: erstellt im aktuellen Ordner ein subdir repos                                                             |
| `git <clone> <URL>` |                 | das Repository - definiert über `<pfad>` - wird in das lokale Dateisystem kopiert (geclont)                    |
| git diff            |                 | zeigt die Änderungen aller Dateien an; mit Q wird das wieder beendet                                                                                                               |

Aufzeichnung der Befehle, um ein Repo herunterzuladen

~~~bash
# wechseln in unser home verzeichnis
cd

# erstellen des Ordners "repos"
mkdir repos

# wechseln in "repos"
cd repos

#clonen des repos in das aktuelle Verzeichnis
 git clone https://gitlab.com/basti-debug/wfsst_4chel_mayrhofer_2022.git
#Zugriff auf das repository mit einem Schlüssel
# dazu muss EINMAL ein Schlüssel generiert werden und auf gitlab
# hinterlegt werden
ssh-keygen

# öffentlicher schlüssel anzeigen
cat ~/.ssh/id_rsa.pub

# jetzt wird diese Anzeige in das clipboard kopiert und auf
#gitlab.com im eigenen Profil unter ssh-keys eingefügt

# nun kann das repo über ssh (und somit ohne Authentifizierung über UID + PW) geladen werden
git clone git@gitlab.com:basti-debug/wfsst_4chel_mayrhofer_2022.git

# einmal in git die Userdaten hinterlegen
git config --global user.name "basti-debug"
git config --global user.email "basti.debug@gmail.com"

#zeigt Änderungen an Dateien an
git status
#Datei im Editor öffnen
vi <Datei>
#eine Dateiebne höhergehen
cd ..
#detaillierte Infos zu allen Dateien im Ordner wiedergeben
ll
#auf eine Datei "fokussieren"
touch <Datei>
#fügt alle Dateien zum repository hinzu (Punkt steht für alle Dateien)
git add .
#hinzufügen einer Nachricht
git commit -am "commit message"
#Datei auf Gitlab hochladen
git push
~~~


code sniplets: 

![[ctorsnip.png]]


# Gitlab features 

![[Pasted image 20221124093848.png]]