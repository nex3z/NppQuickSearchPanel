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

Input keywords and click ![add][3]**add** button to add it to the list. Use ![remove][4]**remove** button to remove the selected keywords. You can also change the order of selected keywords by using ![moveup][5]**Move up** and ![movedown][6]**Move down**.

Use ![import][7]**Import**/![export][8]**Export** to load/save the current keywords list.

Now that you have your keywords list. <kbd>Click</kbd> on keywords to search forward, <kbd>Shift</kbd> + <kbd>Click</kbd> on keywords to search backward.


## How to build

Open the project with Visual Studio 2013 or later. If you encounter a "The system cannot find the file specified" error when building the project, add the location of **NETFX 4.5.1 Tools** to your **Path** environment variable. 

The Typical location of **NETFX 4.5.1 Tools** is ```C:\Program Files (x86)\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools``` for x64 operating system and ```C:\Program Files\Microsoft SDKs\Windows\v8.1A\bin\NETFX 4.5.1 Tools```for x86.


## Credits

- NppPlugin.NET.v0.6, the C# Notepad++ plugin template is brought to you by ufo-pu55y at [here][9].
- The nice toolbar icons come from [famfamfam.com][10], under [Creative Commons Attribution 3.0 License][11].


## About Notepad++

Notepad++ is a free (as in "free speech" and also as in "free beer") source code editor and Notepad replacement that supports several languages. Running in the MS Windows environment, its use is governed by GPL License.
For more information, please refer to the [official site][12].


  [1]: http://blog.nex3z.com/wp-content/uploads/2015/05/screenshot.png
  [2]: http://blog.nex3z.com/wp-content/uploads/2015/05/magnifier.png
  [3]: http://blog.nex3z.com/wp-content/uploads/2015/05/add.png
  [4]: http://blog.nex3z.com/wp-content/uploads/2015/05/delete.png
  [5]: http://blog.nex3z.com/wp-content/uploads/2015/05/arrow_up.png
  [6]: http://blog.nex3z.com/wp-content/uploads/2015/05/arrow_down.png
  [7]: http://blog.nex3z.com/wp-content/uploads/2015/05/folder_page_white.png
  [8]: http://blog.nex3z.com/wp-content/uploads/2015/05/disk.png
  [9]: http://sourceforge.net/projects/sourcecookifier/files/other%20plugins/
  [10]: http://www.famfamfam.com/    "famfamfam.com"
  [11]: http://creativecommons.org/licenses/by/2.5/    "Creative Commons Attribution 3.0 License"
  [12]: https://notepad-plus-plus.org/    "Notepad ++ Home"