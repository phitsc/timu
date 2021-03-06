http://www.donationcoder.com/forum/index.php?topic=36544

# Keyboard shortcuts

~~~
Alt + I : focus input box                          Ctrl + O : open file
Alt + O : focus output box                         Ctrl + S : save file
Alt + D : focus filter box                         Ctrl + Q : quit application
ESC     : clear filter box (when focused)          Ctrl + I : toggle 'ignore case'
                                                   Ctrl + R : toggle 'reverse output'
~~~
# Escape characters

~~~
\\t : Tab
\\n : Newline
~~~

# Command Line Arguments

~~~
-f <name>         or --function <name>           : Name of initially selected function
-i <path_to_file> or --input-file <path_to_file> : Path to text file to load into input field
-p <value>        or --param <value>             : Parameter value for function in order specified
                                                   (provide as many as necessary)
~~~

Put `<value>` in quotes if it contains spaces. Leftover text will be uses as input. If no input is
provided the input field will be populated with what's in the clipboard.

# Version history

0.20 - 16. May 2017

* Fixed window not showing when starting the application after it has been closed while minimized

0.19 - 18. November 2015

* Support capture group references in replacement text for Regex Search & Replace (use \1, \2, etc.)

0.18 - 8. August 2015

* Specify escape characters in help
* Add command line arguments (see above)
* Combine Remove words left/right into Remove words
* Add Remove characters

0.17 - 16. June 2015

* Lines - Split - Add possibility to split by comma

0.16 - 10. September 2014

* Added Lines - Remove duplicates & count unique

0.15 - 1. August 2014

* Fixed incorrect handling of "^" and "$" in regex search & replace

0.14 - 6. May 2014

* Fixed last word and space after word problem with Web - Twitter and List - Trim to size

0.13 - 4. May 2014

* Added Search & Replace - Highlight word multiplication
* Added Web - Twitter
* Added List - Trim to size

0.12 - 5. March 2014

* Added Capitalisation - Title
* Added Capitalisation - Toggle
* Added possibility to use \t for tab and \n for newline where it might make sense

0.11 - 11. Feb 2014

* Renamed category 'List' to 'Lines'
* Renamed category 'Search' to 'Search & Replace'
* Added Search & Replace - highlight non-ascii characters
* Added Lines - Keep / Remove words at beginning / end of lines (can be used to remove line numbers as well)
* Added Lines - remove duplicate lines
* Added Lines - remove extra empty lines
* Added Lines - delete to tag

0.10

* Added Search & Replace
* Can now specify line number start and increment

0.9 - 31. Jan 2014

* Save window size/position and state of 'ignore case' and 'reverse output direction'
* Print number of highlights (matches) in status bar (e.g. in search)
* Highlight filter text
* Added Web - Remove tags

0.8 - 25. Jan 2014

* Fixed reverse words, scramble within words layout
* Added prepend line number
* Added tooltips to the buttons

0.7 - 24. Jan 2014

* Streamlined layout
* Added ignore case toggle button (and Ctrl + I)
* Added reverse output toggle button (and Ctrl + R)
* Some additional keyboard shortcuts
* Using monospace font for input/output boxes
* Clicking the link in About now opens a web browser

0.6 - 22. Jan 2014

* Added filter for text manipulation tree
* Improved keyboard usage
* Added file open and save

0.5 - 18. Jan 2014

* Input field and parameter field now show a hint right above the respective field
* Added
  * Order - Reverse lines
  * Order - Scramble lines

0.4 - 17. Jan 2014

* Parameter field is now disabled if it doesn't apply
* Added
  * List - Remove empty lines
  * List - Append
  * List - Prepend
* Preparation to display hints on Input and Parameter fields
  (currently, F1 toggles a tooltip if a hint is available, but will change
   this to be more obvious)

0.3 - 14. Dec. 2013

* Added sort lines
* List/Split now splits by words instead of by characters (use , to delimit individual words)
* Added some buttons for clipboard operations and to copy output back to input

0.2 - 5. Dec. 2013

* Added to/from Leet
