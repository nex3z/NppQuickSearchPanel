# NppQuickSearchPanel

## Description

**NppQuickSearchPanel** is a notepad++ plugin which stores your favourite keywords in a list, providing fast and convenient searching. You can perform search on any keywords by a click.

![screenshot][1]


## Features

- Manage your frequently used keywords in a list. 
- Click on keywords to search.
- Provide multiple search options and regular expression support.


## How to install 

Copy the **NppQuickSearchPanel.dll** to the **plugins** folder in your Notepad++ directory.

**Important Note:** NppQuickSearchPanel only support the **Unicode** version of Notepad++.


## How to use

Open up Notepad++, click the ![pluginicon][2]**Show QuickSearchPanel** button in the toolbar, or use menu **Plugins / NppQuickSearchPanel / Show QuickSearchPanel**.

- Input keyword in the text box. Click ![add][3]**Add** button or just press <kbd>**Enter**</kbd> to add the keyword to the list. 
- <kbd>**Click**</kbd> on the keyword in the list to search forward. <kbd>**Shift**</kbd> + <kbd>**Click**</kbd> to search backward. 
- <kbd>**Ctrl**</kbd> + <kbd>**Click**</kbd> on the keyword to launch Notepad++ Find dialog with selected keyword pasted in "Find what" automatically.
- Use ![remove][4]**Remove** button to remove the selected keyword. You can also change the order of selected keyword by using ![moveup][5]**Move up** and ![movedown][6]**Move down**.
- Use ![import][7]**Import**/![export][8]**Export** to load/save current keywords list.


## How to build

Build with Visual Studio 2013. If you encounter a "The system cannot find the file specified" error when building the project, add the location of **NETFX Tools** to your **Path** environment variable. 

For 64-bit system and Visual Studio 2013, the typical location of **NETFX Tools** is 
```
C:\Program Files (x86)\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools
```

For 32-bit system, the typical location is 
```
C:\Program Files\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools
```


## Contributors

- [nex3z](https://github.com/nex3z)
- [June3Ningxu](https://github.com/June3Ningxu)


## Credits

- [NppPlugin.NET.v0.6][9], the C# Notepad++ plugin template is brought to you by ufo-pu55y.
- The nice toolbar icons come from [famfamfam.com][10], under [Creative Commons Attribution 3.0 License][11].


## About Notepad++

Notepad++ is a free (as in "free speech" and also as in "free beer") source code editor and Notepad replacement that supports several languages. Running in the MS Windows environment, its use is governed by GPL License.
For more information, please refer to the [official site][12].


  [1]: images/screenshot.png
  [2]: images/icons/magnifier.png
  [3]: images/icons/add.png
  [4]: images/icons/delete.png
  [5]: images/icons/arrow_up.png
  [6]: images/icons/arrow_down.png
  [7]: images/icons/folder_page_white.png
  [8]: images/icons/disk.png
  [9]: http://sourceforge.net/projects/sourcecookifier/files/other%20plugins/
  [10]: http://www.famfamfam.com/    "famfamfam.com"
  [11]: http://creativecommons.org/licenses/by/2.5/    "Creative Commons Attribution 3.0 License"
  [12]: https://notepad-plus-plus.org/    "Notepad ++ Home"