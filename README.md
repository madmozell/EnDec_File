------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Changes №1 (New project C#):

1. An empty C# project has been created.
2. The file was created: ".gitattributes".
3. File created: ".gitignore".
4. A file has been created: “ReadMe.md” - in which the changes to this project will be structurally described in text format.
5. The element “Assembly information...” has been created and configured.
6. The element “Windows Forms” has been created and configured.
7. Added file: "icon.ico" - in the form of a shortcut to the executable (.exe) file.





------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Changes №2 (Interface №1):

    1. The following elements were created and configured on the Windows Forms element (MainForm):
        1.1. Panel: Panel_MainBtn - where the elements are located:
            1.1.1. ComboBox: CB_EncryptMethod - when changed, cipher methods are selected.
            1.1.2. Panel: Panel_CaesarMainBtn - this panel contains buttons that display the main functionality of the cipher.
                1.1.2.1. Button: Btn_CaesarEncryptFile - when pressed, opens a panel with controls for encrypting any files using the key validation method.
                1.1.2.2. Button: Btn_CaesarDecryptFile - when pressed, opens a panel with controls for decrypting any files using the key validation method, as well as the ability to attack the Caesar cipher using a brute force method.
                1.1.2.3. Button: Btn_CaesarText - when pressed, opens a panel with controls for text typing: creating, opening, saving and printing text in any language. It also provides the ability to interactively create a encryption alphabet for encryption in any language.
            1.1.3. Button: Btn_AuthorInfo - a button that displays information about the application developer.
            1.1.4. LinkLabel: LLbl_Version - link to view the current version of the program, as well as information regarding the development of the application (project) on the platform: "GitHub".

        1.2. Panel: Panel_CaesarFileEncrypt - panel where controls for encrypting files of any format are located. This control provides the ability to drag and drop files using the "Drag-and-Drop" method.
            1.2.1. Label: Lbl_0 - name of the encryption method: "CAESAR CIPHER".
            1.2.2. Label: Lbl_1 - hint for the user: "Drag a file of any format into this window to encrypt it."
            1.2.3. Button: Btn_CaesarOpenFileEnc - when pressed, opens an explorer for selecting an encryption file, and also opens the file encryption settings panel.
                1.2.3.1. Panel: Panel_CaesarSaveFileEnc - panel for setting up file encryption, which contains the following controls:
                1.2.3.2. Label: Lbl_2 - panel title, to inform the user: "CAESAR CIPHER SAVE ENCRYPT FILE".
                1.2.3.3. Label: Lbl_3 - hint for the user: "Key".
                1.2.3.4. Label: Lbl_4 - hint for the user: "Path".
                1.2.3.5. TextBox: TB_CaesarKeyEncrypt - field for entering the encryption key.
                1.2.3.6. TextBox: TB_CaesarPathSaveFileEncrypt - a field for displaying and copying by the user the path to the file that is selected and will be encrypted.
                1.2.3.7. Button: Btn_SaveEncFile - when pressed, encrypts the user-selected file and saves the encrypted file to the specified path with the extension: ".lvre".





------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Changes №3 (Code to interface №1):

    1. For the convenience of developing and writing code, a folder was created: "Caesar_Code", where a new file was created: "EncryptFile.cs", with a partial class: "MainForm: Form".
        1.1. The following (private void) methods and events were declared in this file:
            1.1.1. CaesarEncryptFile(string file_path, string key) - this method implements the logic for encrypting a file of any format using a byte shift of the selected file (file_path) by key.
            1.1.2. Btn_CaesarEncryptFile_Click(object sender, EventArgs e) - this method (event), when the button is clicked, opens the control element: "Panel_CaesarFileEncrypt". In the future, functions for closing all previous open panels before opening will be added to this method: "Panel_CaesarFileEncrypt".
            1.1.3. Panel_CaesarFileEncrypt_DragEnter(object sender, DragEventArgs e) - this method (event) causes the mouse cursor to visually change when a file of any format required for encryption is dragged onto the panel: "Panel_CaesarFileEncrypt".
            1.1.4. Panel_CaesarFileEncrypt_DragDrop(object sender, DragEventArgs e) - this method (event), when you hover over the panel: "Panel_CaesarFileEncrypt" and release LMB with the file to encrypt, the panel: "Panel_CaesarSaveFileEnc" becomes visible and enabled for the user and in the field: "TB_CaesarPathSaveFileEncrypt" appears path of the file that will be encrypted.
            1.1.5. Btn_CaesarOpenFileEnc_Click(object sender, EventArgs e) - this method (event), when clicked, opens the explorer for selecting an encryption file, when selecting a file in the dialog box, the panel: "Panel_CaesarSaveFileEnc" becomes visible and enabled for the user and the path appears in the field: "TB_CaesarPathSaveFileEncrypt" file that will be encrypted.
            1.1.6. Btn_SaveEncFile_Click(object sender, EventArgs e) - this method (event), when clicked, executes the method: "CaesarEncryptFile(string file_path, string key)" for the selected file and saves the encrypted file in the same directory changing its extension to: ".lvre" .
            1.1.7. Btn_CaesarCloseSaveFileEnc_Click(object sender, EventArgs e) - this method (event), when clicked, closes the panel: "Panel_CaesarSaveFileEnc".



    2. The following (private void) methods were added to the “Main_Form.cs” file, which are used in other files:
        2.1. Btn_AuthorInfo_Click(object sender, EventArgs e) - this method (event), when the button is clicked, displays information about the author of the project.
        2.2. LLbl_Version_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) - this method (event), when you click on this link, the default browser opens and goes to the specified link: "https://github.com/madmozell/EnDec_File".
        2.3. SampleDragEnter(DragEventArgs e) - this method (event) was created for use in other methods and represents a visual change in the mouse cursor when hovering over an element that uses the event: "DragEnter".



    3. For visual perception of the assigned tasks, the following controls were highlighted in red:
        3.1. ComboBox: CB_EncryptMethod - select the encryption method.
        3.2. Button: Btn_CaesarDecryptFile - opens a panel with controls for decrypting a file of any format using the key validation method, as well as the ability to attack the Caesar cipher using the brute force method.
        3.3. Button: Btn_CaesarText - opens a panel with controls for: creating, opening, saving and typing text in any language with the ability to create an encryption alphabet to encrypt text in any language.



    4*. When running and debugging this Windows Forms application multiple times, no bugs or errors were found.





------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Changes №4 (Interface №2):

    1. Added controls for the section: "DECRYPT FILE", namely:
        1.1. Panel: Panel_CaesarFileDecrypt - the panel on which all controls are located and which is activated by pressing the button: "Btn_CaesarDecryptFile". This panel has the function: "Drag-and-Drop" - which is activated when you drag an encrypted file of any format onto the panel and contains the following controls:
            1.1.1. Label: Lbl_5 - name of the encryption method: "CAESAR CIPHER".
            1.1.2. Label: Lbl_6 - hint for the user: "Drag the encrypted file into this window to decrypt it."
            1.1.3. Button: Btn_CaesarOpenFileDec - when pressed, it opens an explorer for selecting a file for decryption, and also opens a settings panel for decrypting a file of any format.
            1.1.4. Panel: Panel_CaesarSaveFileDec - the panel on which the controls are located and which is activated when selecting a file for decryption using the "Drag-and-Drop" method or by pressing the button: "Btn_CaesarOpenFileDec" and selecting the file from the explorer. This panel contains the following controls:
                1.1.4.1. Label: Lbl_7 - title of the panel, to inform the user: "CAESAR CIPHER SAVE DECRYPT FILE".
                1.1.4.2. Label: Lbl_8 - hint for the user: "Key".
                1.1.4.3. Label: Lbl_9 - hint for the user: "Path".
                1.1.4.4. TextBox: TB_CaesarKeyDecrypt - field for entering the decryption key.
                1.1.4.5. TextBox: TB_CaesarPathSaveFileDecrypt - a field for displaying and copying by the user the path to the file that is selected and will be decrypted.
                1.1.4.6. CheckBox: CheckBox_CaesarEnumerateAllCipher - when this checkbox is activated, the decryption key set field is blocked: "TB_CaesarKeyDecrypt" and the user-selected file is decrypted using a brute-force method from 0 to 255.
                1.1.4.7. Button: Btn_SaveDecFile - when pressed, decrypts the user-selected file and saves the decrypted file to the specified path with the extension: ".lvrd".
                1.1.4.8. Button: Btn_CaesarCloseSaveFileDec - when pressed, closes the panel: "Panel_CaesarSaveFileDec".





------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Changes №5 (Code to interface №2):

    1. In the folder: "Caesar_Code" a file was added: "DecryptFile.cs", with a partial class: "MainForm: Form".
        1.1. The following (private void) methods and events were declared in this file:
            1.1.1. CaesarDecryptFile(string file_path, string key) - A method to decrypt a file based on a byte shift of the file, using the file path and key (offset).
            1.1.2. Btn_CaesarDecryptFile_Click(object sender, EventArgs e) - When clicked, it opens: "Panel_CaesarFileDecrypt" - for decrypting files of any format.
            1.1.3. Panel_CaesarFileDecrypt_DragEnter(object sender, DragEventArgs e) - The visual effect of changing the cursor icon when hovering the cursor while holding RMB with a file.
            1.1.4. Panel_CaesarFileDecrypt_DragDrop(object sender, DragEventArgs e) - When you release the cursor with the file, the file path is written to "TB" and the file saving settings panel opens.
            1.1.5. Btn_CaesarOpenFileDec_Click(object sender, EventArgs e) - When you press the button, the file selection explorer opens, the file path is written to "TB" and the file saving settings panel opens.
            1.1.6. CheckBox_CaesarEnumerateAllCipher_CheckedChanged(object sender, EventArgs e) - When pressed, it activates the function of searching through all file decryption options.
            1.1.7. Btn_SaveDecFile_Click(object sender, EventArgs e) - When you press the button, the file is decrypted and saved using the method: "CaesarEncryptAllFile"
            1.1.8. Btn_CaesarCloseSaveFileDec_Click(object sender, EventArgs e) - When you press the button, the settings panel for saving the decrypted file closes.

        1.2. In the file "EncryptFile.cs", changes were made to the (private void) method: "Btn_CaesarEncryptFile_Click(object sender, EventArgs e)":
            1.2.1. Panel_CaesarFileEncrypt.Visible = true; Panel_CaesarFileEncrypt.Enabled = true; Panel_CaesarFileDecrypt.Visible = false; Panel_CaesarFileDecrypt.Enabled = false; Panel_CaesarText.Visible = false; Panel_CaesarText.Enabled = false;



    2*. When running and debugging this Windows Forms application multiple times, no bugs or errors were found.





------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Changes №6 (Interface №3):

    1. Added controls for the section: "TEXT ENCRYPTION", namely:
        1.1. Panel: Panel_CaesarText - the panel on which all controls are located and which is activated by pressing the button: "Btn_CaesarText". This panel contains the following elements:
            1.1.1. Label: Lbl_10 - name of the encryption method: "CAESAR CIPHER".
            1.1.2. Label: Lbl_11 - hint for the user: "Input text:".
            1.1.3. Label: Lbl_12 - hint for the user: "Alphabet:".
            1.1.4. Label: Lbl_13 - hint for the user: "Shift:".
            1.1.5. Label: Lbl_14 - hint for the user: "Converted text:".
            1.1.6. TextBox: TB_CaesarUserText - a field for entering custom text in any language with the ability to copy text from a file using the "Drag-and-Drop" method.
            1.1.7. Button: Btn_IncreaseFontSize - when pressed, increases the text font by "+2 pt" in the text field of the element: "TB_CaesarUserText".
            1.1.8. Button: Btn_DecreaseFontSize - when pressed, decreases the text font by "-2 pt" in the text field of the element: "TB_CaesarUserText".
            1.1.9. Button: Btn_CaesarSave - when pressed, reads the user file: "Caesar_User_Dictionary.txt" and opens the saving settings panel: "Panel_CaesarSavingText", converted (encrypted) text from the elements: "TB_Converse{i}".
            1.1.10. Button: Btn_CaesarOpenFile - when pressed, opens a file selection dialog in Explorer to transfer text from the file to the field: "TB_CaesarUserText".
            1.1.11. Button: Btn_CaesarCalculate - when pressed, encrypts the text according to the selected alphabet and displays the encryption results in the elements: "TB_Converse{i}" and the sequence number offset: "Lbl_Shift{i}".
            1.1.12. ComboBox: CB_CaesarSelectAlphabet - when changing the value of the element, changes the encryption alphabet, example: "English", "Ukrainian".
            1.1.13. Panel: Panel_CaesarConvert - the panel on which the offset is displayed: "Lbl_Shift{i}" and the converted ciphertext: "TB_Converse{i}", according to the alphabet: "CB_CaesarSelectAlphabet".
                1.1.13.1. Label: Lbl_Shift{i} - displays the ordinal number of the offset (shift) in the alphabet: "ROT 0: ... ROT #:", where i is the ordinal number of the letter in the alphabet.
                1.1.13.2. TextBox: TB_Converse{i} - text conversions of user text, where i is the offset (shift) in the selected alphabet.
                1.1.14. Panel: Panel_CaesarSavingText - a panel that contains the following controls:
            1.1.14.1. Label: Lbl_15 - title of the panel, to inform the user: "CAESAR CIPHER SAVING SETTINGS".
                1.1.14.2. Label: Lbl_16 - hint for the user: "Conversion:".
                1.1.14.3. Label: Lbl_17 - hint for the user: "####" - name of the selected alphabet.
                1.1.14.4. ComboBox: CB_CaesarSelectConverse - when changing the value, displays the text with a shift.
                1.1.14.5. TextBox: TB_CaesarCipherSave - displays the modified text with the selected offset from the element: "CB_CaesarSelectConverse".
                1.1.14.6. Button: Btn_CaesarSaveFile - saves the selected text to a ".txt" file.
                1.1.14.7. Button: Btn_CaesarCloseSavingTextPanel - when pressed, closes the panel: "Panel_CaesarSavingText".





------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Changes №7 (Code to interface №3):

    1. In the folder: "Caesar_Code" a file was added: "TextEnDec.cs", with a partial class: "MainForm: Form".
        1.1. The following variable was declared in this file:
            1.1.1. "string all_char_alphabet" - for storing outside the method the user-selected alphabet from the list of alphabets.

        1.2. The following (private void) methods and events were declared in this file:
            1.2.1. CaesarSaveTextToFile(string save_text) - A method for storing hand-written ciphertext.
            1.2.2. ReadingUserDictionaryAlphabet() - The method is used in the event: when the visibility of an element changes: "Panel_CaesarSaveFileEnc"
            1.2.3. Caesar_CipherCalculateText() - Adds elements for offset based on the selected alphabet in the list by method to the element: "Panel_CaesarConvert".
            1.2.4. Btn_CaesarText_Click(object sender, EventArgs e) - When clicked, it opens: "Panel_CesarText" - for manually writing text and executes the method: "ReadingUserDictionaryAlphabet".
            1.2.5. TB_CaesarUserText_DragEnter(object sender, DragEventArgs e) - The effect when dragging (hovering the cursor with a file) on an element...
            1.2.6. TB_CaesarUserText_DragDrop(object sender, DragEventArgs e) - When you release the RMB with a file, the file text is written to the element: "TB_CaesarUserText"
            1.2.7. TB_CaesarUserText_Enter(object sender, EventArgs e) - A visual effect that displays tooltip text in an element: "TB_CaesarUserText"
            1.2.8. TB_CaesarUserText_Leave(object sender, EventArgs e) - A visual effect that displays tooltip text in an element: "TB_CaesarUserText"
            1.2.9. Btn_IncreaseFontSize_Click(object sender, EventArgs e) - Increase custom text font size.
            1.2.10. Btn_DecreaseFontSize_Click(object sender, EventArgs e) - Decrease custom text font size.
            1.2.11. Btn_CaesarOpenFile_Click(object sender, EventArgs e) - Selecting a text file to read and copy text into the field: "TB_CaesarUserText"
            1.2.12. Btn_CaesarCalculate_Click(object sender, EventArgs e) - Calculate all offsets of the entered text and display offset options on the screen.
            1.2.13. Btn_CaesarSave_Click(object sender, EventArgs e) - When clicked, the settings panel for saving encrypted user text opens.
            1.2.14. CB_CaesarSelectConverse_SelectedIndexChanged(object sender, EventArgs e) - When changing the ComboBox index, the text with the selected offset in the selected alphabet is displayed.
            1.2.15. Btn_CaesarSaveFile_Click(object sender, EventArgs e) - Saves the text from the "TB_CaesarCipherSave" element to a .txt file.
            1.2.16. Btn_CaesarCloseSavingTextPanel_Click(object sender, EventArgs e) - When clicked, the panel for saving the offset of the typed custom text in the selected alphabet closes.



    2*. When running and debugging this Windows Forms application multiple times, no bugs or errors were found.





------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Changes №8 (Code and Interface):

1. Added panel: "PanelComingSoon" - to inform the user about the development of this section.
2*. When running and debugging this Windows Forms application multiple times, no bugs or errors were found.





------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Changes №9 (Release):

1. The performance of this project was tested using the debugging method using a breakpoint.
2. The functionality of all controls has been tested and verified.
3. The executable file was compiled and assembled: "Endec File.exe".
