using System.Collections.Generic;

namespace DriveConnect.Helpers
{
    public static class Translate
    {
        #region Not in resources
        public static string Call_Single { get; } = "Call_single";
        public static string Call_Group { get; } = "Call_group";
        #endregion

        #region Static strings

        #region Login
        public static string Password { get; } = "Password";
        public static string Login { get; } = "Login";
        #endregion

        #region View

        #region ChatHub

        #region For AcmManagement
        public static string Platform_management { get; } = "Platform_management";
        public static string Platform1 { get; } = "Platform1";
        public static string Platform2 { get; } = "Platform2";
        public static string Platform3 { get; } = "Platform3";
        public static string Return { get; } = "Return";
        public static string Current_Device { get; } = "Current_Device";
        #endregion

        #region CalendarView
        public static string January { get; } = "January";
        public static string February { get; } = "February";
        public static string March { get; } = "March";
        public static string April { get; } = "April";
        public static string May { get; } = "May";
        public static string June { get; } = "June";
        public static string July { get; } = "July";
        public static string August { get; } = "August";
        public static string September { get; } = "September";
        public static string October { get; } = "October";
        public static string November { get; } = "November";
        public static string December { get; } = "December";
        public static string Assigned_by { get; } = "Assigned_by";
        public static string Assigned_to { get; } = "Assigned_to";
        public static string Detail { get; } = "Detail";
        public static string Audio_name { get; } = "Audio_name";
        public static string Note_name { get; } = "Note_name";
        public static string Task_name { get; } = "Task_name";
        public static string File_Failed_To_Be_Opened { get; } = "File_Failed_To_Be_Opened";
        public static string Open_The_File { get; } = "Open_The_File";
        #endregion

        #region ChatSettings
        public static string Setting { get; } = "Settings";
        public static string Refresh { get; } = "Refresh";
        public static string Confirm { get; } = "Confirm";
        public static string Settings17 { get; } = "Settings17";
        public static string Settings16 { get; } = "Settings16";
        public static string Settings15 { get; } = "Settings15";
        public static string Settings14 { get; } = "Settings14";
        public static string Settings13 { get; } = "Settings13";
        public static string Settings12 { get; } = "Settings12";
        public static string Settings11 { get; } = "Settings11";
        public static string Settings10 { get; } = "Settings10";
        public static string Settings9 { get; } = "Settings9";
        public static string Settings8 { get; } = "Settings8";
        public static string Settings7 { get; } = "Settings7";
        public static string Settings6 { get; } = "Settings6";
        public static string Settings5 { get; } = "Settings5";
        public static string Settings4 { get; } = "Settings4";
        public static string Settings3 { get; } = "Settings3";
        public static string Settings2 { get; } = "Settings2";
        public static string Settings1 { get; } = "Settings1";
        public static string Manage_My_Platforms { get; } = "Manage_My_Platforms";
        public static string Message_Settings { get; } = "Message_Settings";
        public static string Reminder_Settings { get; } = "Reminder_Settings";
        public static string Settings_Online_Save { get; } = "Settings_Online_Save";
        public static string Multi_Plateform_Settings { get; } = "Multi_Plateform_Settings";
        public static string Langage_Settings { get; } = "Langage_Settings";
        public static string Job_Title { get; } = "Job_Title";
        public static string Job_Description { get; } = "Job_Description";
        public static string Departement { get; } = "Departement";
        public static string Company_Name { get; } = "Company_Name";
        public static string Profile_Settings { get; } = "Profile_Settings";
        public static string ChatUser_Profile_Updated { get; } = "ChatUser_Profile_Updated";
        public static string ChatUser_Profile_Not_Updated { get; } = "ChatUser_Profile_Not_Updated";
        public static string ChatSettings_Updated { get; } = "ChatSettings_Updated";
        public static string ChatSettins_Not_Updated { get; } = "ChatSettins_Not_Updated";
        public static string Update_Profile { get; } = "Update_Profile";
        public static string Not_filled { get; } = "Not_filled";
        public static string Cannot_Remov_Current_Platform { get; } = "Cannot_Remov_Current_Platform";
        public static string Manage_Users { get; } = "Manage_Users";
        public static string Digit_code { get; } = "Digit_code";
        public static string Switch_User { get; } = "Switch_User";
        public static string Delete_User { get; } = "Delete_User";
        public static string Create_Security_Digit { get; } = "Create_Security_Digit";
        public static string Display { get; } = "Display";
        public static string AddNewUserAlert { get; } = "AddNewUserAlert";
        public static string App_reconfiguration_alert { get; } = "App_reconfiguration_alert";
        public static string Download_All_Files_Settings_Title { get; } = "Download_All_Files_Settings_Title";
        public static string Download_All_Files_Settings_Detail { get; } = "Download_All_Files_Settings_Detail";
        public static string Delete_account { get; } = "Delete_account";
        public static string Change_Language { get; } = "Change_Language";
        public static string Manage_App { get; } = "Manage_App";

        #endregion

        #region ChatContactList
        public static string ChatCenter { get; } = "ChatCenter";
        public static string Cancel { get; } = "Cancel";
        public static string Click_to_hide { get; } = "Click_to_hide";
        public static string Group_Creation_Constraints { get; } = "Group_Creation_Constraints";
        public static string Create_a_group { get; } = "Create_a_group";
        public static string Add_new_contact { get; } = "Add_new_contact";
        public static string Add_a_partner { get; } = "Add_a_partner";
        public static string Add_a_colleague { get; } = "Add_a_colleague";
        public static string Contact_name { get; } = "Contact_name";
        public static string Group_list { get; } = "Group_list";
        public static string Contact_list { get; } = "Contact_list";
        public static string Attached_Files { get; } = "Attached_Files";
        public static string Simple_editor { get; } = "Simple_editor";
        public static string Html_editor { get; } = "Html_editor";
        public static string Search_in_messages { get; } = "Search_in_messages";
        public static string Group_Name_Constraints { get; } = "Group_Name_Constraints";
        public static string Profile_name { get; } = "Profile_name";
        public static string Company_partner_name { get; } = "Company_partner_name";
        public static string TypeOfChoice { get; } = "TypeOfChoice";
        public static string PictureOfFile { get; } = "PictureOfFile";
        public static string ChoosePic { get; } = "ChoosePic";
        public static string ChooseFile { get; } = "ChooseFile";
        public static string Character_not_autohorized { get; } = "Character_not_autohorized";
        public static string Pick_from_my_library { get; } = "Pick_from_my_library";
        public static string Pick_from_the_memory { get; } = "Pick_from_the_memory";
        public static string Select { get; } = "Select";
        public static string Deselect { get; } = "Deselect";
        public static string AddUser { get; } = "AddUser";
        public static string RemoveUser { get; } = "RemoveUser";
        public static string Confirm_suppression_from_group { get; } = "Confirm_suppression_from_group";
        public static string Error_during_suppression_in_group { get; } = "Error_during_suppression_in_group";
        public static string Warining_group_with_minimum_users { get; } = "Warining_group_with_minimum_users";
        public static string An_error_occured { get; } = "An_error_occured";
        public static string Group_Name { get; } = "Group_Name";
        public static string File_Downloading { get; } = "File_Downloading";
        public static string Download_All_Files { get; } = "Download_All_Files";
        public static string File_Downloaded_Open_It { get; } = "File_Downloaded_Open_It";
        public static string File_Already_Exist_In_The_List { get; } = "File_Already_Exist_In_The_List";
        public static string Connection_Request { get; } = "Connection_Request";
        public static string Missing_reference { get; } = "Missing_reference";
        public static string Filter_By { get; } = "Filter_By";
        public static string By_company { get; } = "By_company";
        public static string By_Activity_Area { get; } = "By_Activity_Area";
        public static string No_Connection_Request { get; } = "No_Connection_Request";
        public static string Connection_request_To { get; } = "Connection_request_To";
        public static string Message { get; } = "Message";
        public static string Connection_Request_Sended { get; } = "Connection_Request_Sended";
        public static string Connection_Request_Accepted { get; } = "Connection_Request_Accepted";
        public static string Connection_Request_Rejected { get; } = "Connection_Request_Rejected";
        public static string Advanced_Search { get; } = "Advanced_Search";
        public static string Filter_Jobtitle { get; } = "Filter_Jobtitle";
        public static string Internal_Contact { get; } = "Internal_Contact";
        public static string External_contact { get; } = "External_contact";
        public static string Filter_ProfileName { get; } = "Filter_ProfileName";
        public static string First_Contact { get; } = "First_Contact";
        public static string Select_a_date { get; } = "Select_a_date";
        public static string Select_an_good_Schedule { get; } = "Select_an_good_Schedule";
        #endregion

        #region GalleryChatRoom
        public static string Files_Management { get; } = "Files_Management";
        public static string Click_to_mark_as_read { get; } = "Click_to_mark_as_read";
        public static string Audio_Note_For_Read_Status { get; } = "Audio_Note_For_Read_Status";
        public static string Show_The_Player { get; } = "Show_The_Player";
        public static string End_Date { get; } = "End_Date";
        public static string Start_Date { get; } = "Start_Date";
        public static string Type_of_publication { get; } = "Type_of_publication";
        public static string YourNoteLabel { get; } = "YourNoteLabel";
        public static string Title { get; } = "Title";
        public static string Record_duration { get; } = "Record_duration";
        public static string Select_User_For_Audio { get; } = "Select_User_For_Audio";
        public static string Inbox_date { get; } = "Inbox_date";
        public static string Click_to_open { get; } = "Click_to_open";
        public static string Audio { get; } = "Audio";
        public static string Note { get; } = "Note";
        public static string Task { get; } = "Task";
        public static string FileName { get; } = "FileName";
        public static string PublicationAudioText1 { get; } = "PublicationAudioText1";
        public static string PublicationAudioText2 { get; } = "PublicationAudioText2";
        public static string Audio_recording_for { get; } = "Audio_recording_for";
        public static string Note_for { get; } = "Note_for";
        public static string Schedule_task_for { get; } = "Schedule_task_for";
        public static string Empty_note_name { get; } = "Empty_note_name";
        public static string NoteName1 { get; } = "NoteName1";
        public static string NoteName2 { get; } = "NoteName2";
        public static string NoteName3 { get; } = "NoteName3";
        public static string Start_Date_Warning { get; } = "Start_Date_Warning";
        public static string DeadLine_Warning { get; } = "DeadLine_Warning";
        public static string Type_contact_name { get; } = "Type_contact_name";
        public static string Default { get; } = "Default";
        public static string Date { get; } = "Date";
        public static string Name { get; } = "Name";
        public static string Sender { get; } = "Sender";
        public static string Type_of_publication_subtext { get; } = "Type_of_publication_subtext";
        public static string Task_name_mandatory { get; } = "Task_name_mandatory";
        public static string Task_note_optional { get; } = "Task_note_optional";
        public static string No_user { get; } = "No_user";
        public static string Audio_record_name_mandatory { get; } = "Audio_record_name_mandatory";
        public static string ascending { get; } = "ascending";
        public static string descending { get; } = "descending";
        public static string Starts_in { get; } = "Starts_in";
        public static string Deadline_in { get; } = "Deadline_in";
        public static string days { get; } = "days";
        public static string DateSortBy { get; } = "DateSortBy";
        public static string Month { get; } = "Month";
        public static string Transfert_to_my_library { get; } = "Transfert_to_my_library";
        public static string Transfer { get; } = "Transfer";
        public static string Choose_folder { get; } = "Choose_folder";
        public static string Empty_library { get; } = "Empty_library";
        public static string Create_folder_in_your_library { get; } = "Create_folder_in_your_library";
        public static string Transfer_the_latest_version { get; } = "Transfer_the_latest_version";
        public static string Transfer_all_versions { get; } = "Transfer_all_versions";
        public static string Warning_Note_Will_Be_Delete { get; } = "Warning_Note_Will_Be_Delete";
        public static string Warning_Task_Will_Be_Delete { get; } = "Warning_Task_Will_Be_Delete";
        public static string Download_it_now { get; } = "Download_it_now";
        public static string ErrorExtraDataPosted1 { get; } = "ErrorExtraDataPosted1";
        public static string ErrorExtraDataPosted2 { get; } = "ErrorExtraDataPosted2";
        public static string ErrorExtraDataPosted3 { get; } = "ErrorExtraDataPosted3";
        public static string ExtraDataPosted1 { get; } = "ExtraDataPosted1";
        public static string ExtraDataPosted2 { get; } = "ExtraDataPosted2";
        public static string Minimum_Task_Name_Char { get; } = "Minimum_Task_Name_Char";
        public static string Year { get; } = "Year";
        public static string Day { get; } = "Day";
        public static string Week { get; } = "Week";
        #endregion

        #endregion

        #region Common
        public static string Redirect_To { get; } = "Redirect_To";
        public static string Redirection { get; } = "Redirection";
        public static string Hours { get; } = "Hours";
        public static string Minutes { get; } = "Minutes";
        public static string Seconds { get; } = "Seconds";
        public static string Notification { get; } = "Notification";
        public static string Contact { get; } = "Contact";
        public static string Not_Connected { get; } = "Not_Connected";
        public static string User_is_not_available { get; } = "User_is_not_available";
        #endregion

        #region Documentary

        #region MyFilesDoc
        public static string Warning_file_already_opened2 { get; } = "Warning_file_already_opened2";
        public static string Save_now { get; } = "Save_now";
        public static string Images { get; } = "Images";
        public static string Videos { get; } = "Videos";
        public static string Audios { get; } = "Audios";
        public static string File_missing_local { get; } = "File_missing_local";
        public static string Try_download_online_file { get; } = "Try_download_online_file";
        public static string Encryption_File_Error { get; } = "Encryption_File_Error";
        public static string File_Already_Exist { get; } = "File_Already_Exist";
        #endregion

        #region PersonalDocumentary
        public static string My_library { get; } = "My_library";
        public static string Search_folders { get; } = "Search_folders";
        public static string Search_files { get; } = "Search_files";
        public static string Create_Folder { get; } = "Create_Folder";
        public static string Add_Files { get; } = "Add_Files";
        public static string Favorites_folders { get; } = "Favorites_folders";
        public static string Folder_name_empty_error { get; } = "Folder_name_empty_error";
        public static string Folder_Name { get; } = "Folder_Name";
        public static string Delete_Personnal_Library { get; } = "Delete_Personnal_Library";
        public static string Folder_creation_failed { get; } = "Folder_creation_failed";
        public static string Add_to_favorites { get; } = "Add_to_favorites";
        public static string Show_folder_option_first1 { get; } = "Show_folder_option_first1";
        public static string Show_folder_option_first2 { get; } = "Show_folder_option_first2";
        public static string Store_all_online { get; } = "Store_all_online";
        public static string Open_the_folder { get; } = "Open_the_folder";
        public static string Remove_from_favorites { get; } = "Remove_from_favorites";
        public static string Save_online { get; } = "Save_online";
        public static string Save_locally { get; } = "Save_locally";
        public static string Delete_folder { get; } = "Delete_folder";
        public static string Delete_folder_and_files_warning { get; } = "Delete_folder_and_files_warning";
        public static string Folder_Already_exist { get; } = "Folder_Already_exist";
        public static string Folder_settings { get; } = "Folder_settings";
        public static string Show_file_option_first1 { get; } = "Show_file_option_first1";
        public static string Show_file_option_first2 { get; } = "Show_file_option_first2";
        public static string Save_all_file_folder_online { get; } = "Save_all_file_folder_online";
        public static string Favorites_files { get; } = "Favorites_files";
        public static string Delete_from_favorites { get; } = "Delete_from_favorites";
        public static string Add_Reference { get; } = "Add_Reference";
        public static string Rename_Folder { get; } = "Rename_Folder";
        public static string Rename_Folder_Failded1 { get; } = "Rename_Folder_Failded1";
        public static string Rename_Folder_Failded2 { get; } = "Rename_Folder_Failded2";
        public static string Moving_files_in_progress { get; } = "Moving_files_in_progress";
        public static string Saving_files_in_progress { get; } = "Saving_files_in_progress";
        public static string Loading_user_personal_library { get; } = "Loading_user_personal_library";
        public static string Latin_characters_only { get; } = "Latin_characters_only";
        public static string No_special_characters { get; } = "No_special_characters";
        public static string Multiple_Selection { get; } = "Multiple_Selection";
        public static string Single_Selection { get; } = "Single_Selection";
        public static string Folder_Update_failed { get; } = "Folder_Update_failed";
        public static string Select_all { get; } = "Select_all";
        public static string Unselect_all { get; } = "Unselect_all";
        public static string Total_progression { get; } = "Total_progression";
        public static string Favorite_add_remove { get; } = "Favorite_add_remove";
        public static string Save_online_locally { get; } = "Save_online_locally";
        public static string Search_favorites_folders { get; } = "Search_favorites_folders";
        public static string Search_favorites_files { get; } = "Search_favorites_files";
        public static string Processing_files1 { get; } = "Processing_files1";
        public static string Processing_files2 { get; } = "Processing_files2";
        public static string Processing_files3 { get; } = "Processing_files3";
        public static string configure_files { get; } = "configure_files";
        public static string Register_this { get; } = "Register_this";
        public static string Register_everything { get; } = "Register_everything";
        public static string Warning_Config_Files { get; } = "Warning_Config_Files";
        public static string Update_File_Settings { get; } = "Update_File_Settings";
        public static string Saving_search_ref { get; } = "Saving_search_ref";
        public static string Deleting_files { get; } = "Deleting_files";
        public static string File_already_opened { get; } = "File_already_opened";
        public static string Warning_file_already_opened { get; } = "Warning_file_already_opened";
        public static string Auto_saved { get; } = "Auto_saved";
        public static string Saved_manually { get; } = "Saved_manually";
        public static string File_history { get; } = "File_history";
        public static string Other_options { get; } = "Other_options";
        public static string File_Update_failed { get; } = "File_Update_failed";
        public static string Delete_all_file_version { get; } = "Delete_all_file_version";
        public static string File_deletion_failed { get; } = "File_deletion_failed";
        public static string Files_deletion_failed { get; } = "Files_deletion_failed";
        public static string Similar_filename_in_lower_case { get; } = "Similar_filename_in_lower_case";
        public static string Delete_file_versions { get; } = "Delete_file_versions";
        public static string Save_all_files_opened { get; } = "Save_all_files_opened";
        public static string Reset { get; } = "Reset";
        public static string Choose_version_of_file_to_delete { get; } = "Choose_version_of_file_to_delete";
        public static string All_files_older_than_a_year_old { get; } = "All_files_older_than_a_year_old";
        public static string All_files_older_than_six_months { get; } = "All_files_older_than_six_months";
        public static string All_files_older_than_three_months { get; } = "All_files_older_than_three_months";
        public static string All_files_older_than_a_month { get; } = "All_files_older_than_a_month";
        public static string Warning_on_file_autosave { get; } = "Warning_on_file_autosave";
        public static string Alert_on_auto_Save { get; } = "Alert_on_auto_Save";
        public static string Search_in_files { get; } = "Search_in_files";
        public static string Click_to_open_the_folder { get; } = "Click_to_open_the_folder";
        public static string Search_in_Sidebar { get; } = "Search_in_Sidebar";
        public static string My_keywords { get; } = "My_keywords";
        public static string Generated_keywords { get; } = "Generated_keywords";
        public static string Generates_auto_research_references { get; } = "Generates_auto_research_references";
        public static string Automatically_generate_research_references { get; } = "Automatically_generate_research_references";
        public static string Choose_SearchReference { get; } = "Choose_SearchReference";
        public static string Deleting_added_search_references { get; } = "Deleting_added_search_references";
        public static string Deleting_generated_search_references { get; } = "Deleting_generated_search_references";
        public static string Error_reregistering_added_search_references { get; } = "Error_reregistering_added_search_references";
        public static string Error_reregistering_generated_search_references { get; } = "Error_reregistering_generated_search_references";
        public static string Search_added_references { get; } = "Search_added_references";
        public static string Search_generated_references { get; } = "Search_generated_references";
        public static string Deleting_added_search_references_files { get; } = "Deleting_added_search_references_files";
        public static string Deleting_generated_search_references_files { get; } = "Deleting_generated_search_references_files";
        public static string Error_reregistering_added_search_references_Files { get; } = "Error_reregistering_added_search_references_Files";
        public static string Error_reregistering_generated_search_references_Files { get; } = "Error_reregistering_generated_search_references_Files";
        public static string Basics_Options { get; } = "Basics_Options";
        public static string What_do_you_want_to_do { get; } = "What_do_you_want_to_do";
        public static string Updating_files_keywords_references { get; } = "Updating_files_keywords_references";
        public static string Restrictive_search { get; } = "Restrictive_search";
        public static string MyDocuments { get; } = "MyDocuments";
        public static string Files { get; } = "Files";
        public static string Library { get; } = "Library";
        public static string Folder_name_missing { get; } = "Folder_name_missing";
        public static string Errors_reports { get; } = "Errors_reports";
        public static string Open { get; } = "Open";
        public static string Delete { get; } = "Delete";
        public static string Retrieve_basics_parameters { get; } = "Retrieve_basics_parameters";
        public static string Configuring_auto_research_parameters { get; } = "Configuring_auto_research_parameters";
        public static string Creating_restriction_list_of_research_parameters { get; } = "Creating_restriction_list_of_research_parameters";

        #endregion

        #endregion

        #region OptionsPages

        #region AppOption
        public static string Is_Already_Opened { get; } = "Is_Already_Opened";
        public static string Action_plan { get; } = "Action_plan";
        public static string Company_library { get; } = "Company_library";
        public static string Branding { get; } = "Branding";
        public static string Calculator { get; } = "Calculator";
        public static string Memo { get; } = "Memo";
        public static string Scoring_sheet { get; } = "Scoring_sheet";
        public static string Restart_App_To_Change_Language { get; } = "Restart_App_To_Change_Language";
        public static string Close_all_app_windows { get; } = "Close_all_app_windows";
        public static string Memo_Title_Already_Exist { get; } = "Memo_Title_Already_Exist";
        public static string Mark_all_as_read { get; } = "Mark_all_as_read";
        public static string Results { get; } = "Results";
        public static string Click_To_Copy { get; } = "Click_To_Copy";
        #endregion

        #endregion

        #region Tutorial

        #region For turorials

        #region 1. GettingStarted
        public static string GettingStartedTuto { get; } = "Create the first company account";
        public static string GettingStartedTutoVideoLink { get; } = "_rtck1ScTH0";
        public static string GettingStartedTutoDescription { get; } =
            "In this video, we guide you in all mandatory steps to " +
            "create the first company account," +
            "test your login," +
            "personalize your ACM account.";
        #endregion

        #region 2. GettingStarted - AuthorizedAccount
        public static string AuthorizedAccount { get; } = "Create authorized accounts";
        public static string AuthorizedAccountVideoLink { get; } = "g3EhJP4OVPI";
        public static string AuthorizedAccountDescription { get; } =
            "Creating authorized accounts for employee is a mandatory step to " +
            "allows them using ACM application under the company autority. In this video, we are guiding your during this process. " +
            "Note that, team supervisor can also create the account only if emails have been authorized previously by an IT member (confer: 01:44 to 02:53)";
        #endregion

        #region 3. GettingStarted - AccountConfirmation
        public static string AccountConfirmation { get; } = "Login from App: Account confirmation";
        public static string AccountConfirmationVideoLink { get; } = "ZtPbl3dwahs";
        public static string AccountConfirmationDescription { get; } =
            "In this video, we are showing you how to confirm your user account after his creation by" +
            "an IT department member or a team supervisor.";
        #endregion

        #region 4. GettingStarted - LoginFromApp
        public static string LoginFromApp { get; } = "Login from app: with authorized account";
        public static string LoginFromAppVideoLink { get; } = "ZNRLyvz5KNE";
        public static string LoginFromAppDescription { get; } =
            "In this video, we are showing you how simple it is to login from ACM application after your account confirmation.";
        #endregion

        #endregion

        #region For tutorials video page
        public static string GettingStarted { get; } = "Getting started";
        public static string ManageContact { get; } = "Manage contacts";
        public static string ManageGroups { get; } = "Manage groups";
        public static string ManageProjects { get; } = "Manage projects";
        public static string Documentary_Management { get; } = "Documentary_Management";
        #endregion

        #region Tutorial pages
        public static string DisplayAlertEndTuto { get; } = "TutoEndOfTurial";
        #endregion

        #region TutorialFirstLaunch
        public static string TutoPopup1Title { get; } = "TutoPopup1Title";
        public static string TutoPopup1Subtitle { get; } = "TutoPopup1Subtitle";
        public static string TutoPopup1BodyLine1 { get; } = "TutoPopup1BodyLine1";
        public static string TutoPopup1BodyLine2 { get; } = "TutoPopup1BodyLine2";
        public static string TutoPopup1BodyLine3 { get; } = "TutoPopup1BodyLine3";
        public static string TutoPopup1BodyLine4 { get; } = "TutoPopup1BodyLine4";
        public static string TutoPopup1BodyLine5 { get; } = "TutoPopup1BodyLine5";
        public static string TutoPopup1BodyLine6 { get; } = "TutoPopup1BodyLine6";
        public static string TutoPopup1BodyLine7 { get; } = "TutoPopup1BodyLine7";
        public static string TutoPopup2Title { get; } = "TutoPopup2Title";
        public static string TutoPopup2Subtitle { get; } = "TutoPopup2Subtitle";
        public static string TutoPopup2BodyLine1 { get; } = "TutoPopup2BodyLine1";
        public static string TutoPopup2BodyLine2 { get; } = "TutoPopup2BodyLine2";
        public static string TutoPopup2BodyLine3 { get; } = "TutoPopup2BodyLine3";
        public static string TutoPopup2BodyLine4 { get; } = "TutoPopup2BodyLine4";
        public static string TutoPopup2BodyLine5 { get; } = "TutoPopup2BodyLine5";
        public static string TutoPopup2BodyLine6 { get; } = "TutoPopup2BodyLine6";
        public static string TutoPopup2BodyLine7 { get; } = "TutoPopup2BodyLine7";
        public static string TutoPopup3Title { get; } = "TutoPopup3Title";
        public static string TutoPopup3Subtitle { get; } = "TutoPopup3Subtitle";
        public static string TutoPopup3BodyLine1 { get; } = "TutoPopup3BodyLine1";
        public static string TutoPopup3BodyLine2 { get; } = "TutoPopup3BodyLine2";
        public static string TutoPopup3BodyLine3 { get; } = "TutoPopup3BodyLine3";
        public static string TutoPopup3BodyLine4 { get; } = "TutoPopup3BodyLine4";
        public static string TutoPopup3BodyLine5 { get; } = "TutoPopup3BodyLine5";
        public static string TutoPopup3BodyLine6 { get; } = "TutoPopup3BodyLine6";
        public static string TutoPopup3BodyLine7 { get; } = "TutoPopup3BodyLine7";
        public static string TutoPopup4Title { get; } = "TutoPopup4Title";
        public static string TutoPopup4Subtitle { get; } = "TutoPopup4Subtitle";
        public static string TutoPopup4BodyLine1 { get; } = "TutoPopup4BodyLine1";
        public static string TutoPopup4BodyLine2 { get; } = "TutoPopup4BodyLine2";
        public static string TutoPopup4BodyLine3 { get; } = "TutoPopup4BodyLine3";
        public static string TutoPopup4BodyLine4 { get; } = "TutoPopup4BodyLine4";
        public static string TutoPopup4BodyLine5 { get; } = "TutoPopup4BodyLine5";
        public static string TutoPopup4BodyLine6 { get; } = "TutoPopup4BodyLine6";
        public static string TutoPopup4BodyLine7 { get; } = "TutoPopup4BodyLine7";
        public static string TutoPopup5Title { get; } = "TutoPopup5Title";
        public static string TutoPopup5Subtitle { get; } = "TutoPopup5Subtitle";
        public static string TutoPopup5BodyLine1 { get; } = "TutoPopup5BodyLine1";
        public static string TutoPopup5BodyLine2 { get; } = "TutoPopup5BodyLine2";
        public static string TutoPopup5BodyLine3 { get; } = "TutoPopup5BodyLine3";
        public static string TutoPopup5BodyLine4 { get; } = "TutoPopup5BodyLine4";
        public static string TutoPopup5BodyLine5 { get; } = "TutoPopup5BodyLine5";
        public static string TutoPopup5BodyLine6 { get; } = "TutoPopup5BodyLine6";
        public static string TutoPopup5BodyLine7 { get; } = "TutoPopup5BodyLine7";
        public static string TutoPopup6Title { get; } = "TutoPopup6Title";
        public static string TutoPopup6Subtitle { get; } = "TutoPopup6Subtitle";
        public static string TutoPopup6BodyLine1 { get; } = "TutoPopup6BodyLine1";
        public static string TutoPopup6BodyLine2 { get; } = "TutoPopup6BodyLine2";
        public static string TutoPopup6BodyLine3 { get; } = "TutoPopup6BodyLine3";
        public static string TutoPopup6BodyLine4 { get; } = "TutoPopup6BodyLine4";
        public static string TutoPopup6BodyLine5 { get; } = "TutoPopup6BodyLine5";
        public static string TutoPopup6BodyLine6 { get; } = "TutoPopup6BodyLine6";
        public static string TutoPopup6BodyLine7 { get; } = "TutoPopup6BodyLine7";
        public static string CommonBottomText { get; } = "CommonBottomText";
        public static string TutoEndOfTurial { get; } = "TutoEndOfTurial";
        #endregion

        #endregion

        #region Carrousel pages
        public static string All { get; } = "All";
        public static string ThisWeek { get; } = "ThisWeek";
        public static string ThisMonth { get; } = "ThisMonth";
        public static string ThisQuarter { get; } = "ThisQuarter";
        public static string Before { get; } = "Before";
        #endregion

        #endregion

        #region ViewModels

        #region ChatModels
        public static string RunningMessage20 { get; } = "RunningMessage20";
        public static string RunningMessage19 { get; } = "RunningMessage19";
        public static string RunningMessage18 { get; } = "RunningMessage18";
        public static string RunningMessage17 { get; } = "RunningMessage17";
        public static string RunningMessage16 { get; } = "RunningMessage16";
        public static string RunningMessage15 { get; } = "RunningMessage15";
        public static string RunningMessage14 { get; } = "RunningMessage14";
        public static string RunningMessage13 { get; } = "RunningMessage13";
        public static string RunningMessage12 { get; } = "RunningMessage12";
        public static string RunningMessage11 { get; } = "RunningMessage11";
        public static string RunningMessage10 { get; } = "RunningMessage10";
        public static string RunningMessage9 { get; } = "RunningMessage9";
        public static string RunningMessage8 { get; } = "RunningMessage8";
        public static string RunningMessage7 { get; } = "RunningMessage7";
        public static string RunningMessage6 { get; } = "RunningMessage6";
        public static string RunningMessage5 { get; } = "RunningMessage5";
        public static string RunningMessage4 { get; } = "RunningMessage4";
        public static string RunningMessage3 { get; } = "RunningMessage3";
        public static string RunningMessage2 { get; } = "RunningMessage2";
        public static string RunningMessage1 { get; } = "RunningMessage1";
        public static string RunningMessage_Split1 { get; } = "RunningMessage_Split1";
        public static string RunningMessage_Split2 { get; } = "RunningMessage_Split2";
        public static string RunningMessage_Split3 { get; } = "RunningMessage_Split3";
        public static string Removed_From_ChatGroup1 { get; } = "Removed_From_ChatGroup1";
        public static string Removed_From_ChatGroup2 { get; } = "Removed_From_ChatGroup2";
        public static string Hub_not_Reconnect { get; } = "Hub_not_Reconnect";
        public static string Cannot_proceed_for_the_moment { get; } = "Cannot_proceed_for_the_moment";
        public static string Nb_Files_To_Download { get; } = "Nb_Files_To_Download";
        public static string File_Download { get; } = "File_Download";
        public static string Message_Retrieve { get; } = "Message_Retrieve";
        public static string Update_data_management { get; } = "Update_data_management";
        public static string Message_Reference { get; } = "Message_Reference";
        #endregion

        #region TaskCalendarViewer
        public static string Sunday { get; } = "Sunday";
        public static string Monday { get; } = "Monday";
        public static string Tuesday { get; } = "Tuesday";
        public static string Wednesday { get; } = "Wednesday";
        public static string Thursday { get; } = "Thursday";
        public static string Friday { get; } = "Friday";
        public static string Saturday { get; } = "Saturday";
        public static string Calendar { get; } = "Calendar";
        #endregion

        #endregion

        #region Others

        #region Common
        public static string In_progress { get; } = "In_progress";
        public static string Previous { get; } = "Previous";
        public static string Next { get; } = "Next";
        public static string Group_Deletion_EndProcess1 { get; } = "Group_Deletion_EndProcess1";
        public static string Group_Deletion_EndProcess2 { get; } = "Group_Deletion_EndProcess2";
        public static string ChatUser_Missing { get; } = "ChatUser_Missing";
        public static string ChatUser_Missing_Configuration { get; } = "ChatUser_Missing_Configuration";
        public static string Group_Deletion_Notification { get; } = "Group_Deletion_Notification";
        public static string Group_User_Failed_To_Be_Deleted { get; } = "Group_User_Failed_To_Be_Deleted";
        public static string Group_User_Failed_To_Be_Recovered { get; } = "Group_User_Failed_To_Be_Recovered";
        public static string Group_User_Has_Been_Recovered { get; } = "Group_User_Has_Been_Recover";
        public static string Reject { get; } = "Reject";
        public static string Minimum_License_Requirement { get; } = "Minimum_License_Requirement";
        public static string Create { get; } = "Create";
        public static string Search_memo { get; } = "Search_memo";
        public static string Feature_not_availabled { get; } = "Feature_not_availabled";
        #endregion

        #region DisplayAlert
        public static string Yes { get; } = "Yes";
        public static string No { get; } = "No";
        public static string Continue { get; } = "Continue";
        public static string No_User_Ref_Found { get; } = "No_User_Ref_Found";
        public static string Error { get; } = "Error";
        public static string Login_requirement { get; } = "Login_requirement";
        public static string Would_you_like_to_login_now { get; } = "Would_you_like_to_login_now";
        public static string Automatic_login_failed { get; } = "Automatic_login_failed";
        public static string Try_to_login_normally { get; } = "Try_to_login_normally";
        public static string You_cannot_access_to_these_features { get; } = "You_cannot_access_to_these_features";
        public static string Try_again_to_login { get; } = "Try_again_to_login";
        public static string Camera_access_permission { get; } = "Camera_access_permission";
        public static string Camera_access_permission_message { get; } = "Camera_access_permission_message";
        public static string Acceptance_required_permission { get; } = "Acceptance_required_permission";
        public static string Audio_Record_permission { get; } = "Audio_Record_permission";
        public static string Audio_Record_permission_message { get; } = "Audio_Record_permission_message";
        public static string Internet_Required_To_Configure { get; } = "Internet_Required_To_Configure";
        public static string Activated_Internet_Try_Again { get; } = "Activated_Internet_Try_Again";
        public static string Login_Error { get; } = "Login_Error";
        public static string Got_it { get; } = "Got_it";
        public static string Success { get; } = "Success";
        public static string Schedule_task_has_not_stored { get; } = "Schedule_task_has_not_stored";
        public static string Close { get; } = "Close";
        public static string Schedule_task_has_been_stored { get; } = "Schedule_task_has_been_stored";
        public static string Reminder_request { get; } = "Reminder_request";
        public static string Always_Reming_Me_Personnal_Task { get; } = "Always_Reming_Me_Personnal_Task";
        public static string Add_To_Reminder { get; } = "Add_To_Reminder";
        public static string Remind_Me_This_Task { get; } = "Remind_Me_This_Task";
        public static string The_note_has_been_stored { get; } = "The_note_has_been_stored";
        public static string The_note_has_not_stored { get; } = "The_note_has_not_stored";
        public static string but_has_been { get; } = "but_has_been";
        public static string Failure { get; } = "Failure";
        public static string Audio_note_been_stored { get; } = "Audio_note_been_stored";
        public static string Audio_note_has_not_stored { get; } = "Audio_note_has_not_stored";
        public static string Notification_update_failed { get; } = "Notification_update_failed";
        public static string Internet_connexion_required { get; } = "Internet_connexion_required";
        public static string File_not_found { get; } = "File_not_found";
        public static string reference_failed_to_be_stored { get; } = "reference_failed_to_be_stored";
        public static string Storing_new_extra_data { get; } = "Storing_new_extra_data";
        public static string Top_message { get; } = "Top_message";
        public static string File_Not_Encrypted { get; } = "File_Not_Encrypted";
        public static string Verify_your_internet_connection { get; } = "Verify_your_internet_connection";
        public static string Content { get; } = "Content";
        public static string ChatRoom_Not_Found { get; } = "ChatRoom_Not_Found";
        public static string ChatRoom_Not_Found_Online { get; } = "ChatRoom_Not_Found_Online";
        public static string ChatRoom_Not_Found1 { get; } = "ChatRoom_Not_Found1";
        public static string Warning { get; } = "Warning";
        public static string Successful_user_add { get; } = "Successful_user_add";
        public static string Add_another_user { get; } = "Add_another_user";
        public static string User_not_stored_in_contact_list { get; } = "User_not_stored_in_contact_list";
        public static string Successful_group_add { get; } = "Successful_group_add";
        public static string User_already_in_contact_list { get; } = "User_already_in_contact_list";
        public static string User_not_stored_in_contact_list1 { get; } = "User_not_stored_in_contact_list1";
        public static string Contact_us { get; } = "Contact_us";
        public static string Error_Message { get; } = "Error_Message";
        public static string Login_reset_response { get; } = "Login_reset_response";
        public static string Retry { get; } = "Retry";
        public static string Wrong_Device { get; } = "Wrong_Device";
        public static string Not_allow_to_login { get; } = "Not_allow_to_login";
        public static string Cannot_get_your_company_name { get; } = "Cannot_get_your_company_name";
        public static string Wrong_username1 { get; } = "Wrong_username1";
        public static string Wrong_username2 { get; } = "Wrong_username2";
        public static string User_not_authorize_by_his_company { get; } = "User_not_authorize_by_his_company";
        public static string Operation_canceled { get; } = "Operation_canceled";
        public static string Server_Duplicate_Auth_User { get; } = "Server_Duplicate_Auth_User";
        public static string Delete_User_Before_Adding { get; } = "Delete_User_Before_Adding";
        public static string Min_char_app_name { get; } = "Min_char_app_name";
        public static string Max_char_app_name { get; } = "Max_char_app_name";
        public static string Username_is_mandatory { get; } = "Username_is_mandatory";
        public static string Confirm_user_config1 { get; } = "Confirm_user_config1";
        public static string Confirm_user_config2 { get; } = "Confirm_user_config2";
        public static string Username { get; } = "Username";
        public static string Authorize_new_beta_testor { get; } = "Authorize_new_beta_testor";
        public static string Confirm_Profile_name1 { get; } = "Confirm_Profile_name1";
        public static string Confirm_Profile_name2 { get; } = "Confirm_Profile_name2";
        public static string Confirm_Profile_name3 { get; } = "Confirm_Profile_name3";
        public static string Input_error { get; } = "Input_error";
        public static string Not_authorized_to_use_the_account { get; } = "Not_authorized_to_use_the_account";
        public static string Send_text_or_files { get; } = "Send_text_or_files";
        public static string No_support_application { get; } = "No_support_application";
        public static string does_not_exist { get; } = "does_not_exist";
        public static string Reduce_the_editor_panel_first { get; } = "Reduce_the_editor_panel_first";
        public static string Alert { get; } = "Alert";
        public static string The_text_edit_will_be_erased { get; } = "The_text_edit_will_be_erased";
        public static string Max_file_size { get; } = "Max_file_size";
        public static string Alreary_in_list { get; } = "Alreary_in_list";
        public static string File_Number_limitation1 { get; } = "File_Number_limitation1";
        public static string File_Number_limitation2 { get; } = "File_Number_limitation2";
        public static string No_file_selected { get; } = "No_file_selected";
        public static string Procedure_Error { get; } = "Procedure_Error";
        public static string Choose_a_of_a_group_first { get; } = "Choose_a_of_a_group_first";
        public static string Restriction { get; } = "Restriction";
        public static string Max_group_add_message1 { get; } = "Max_group_add_message1";
        public static string Max_group_add_message2 { get; } = "Max_group_add_message2";
        public static string No_Files_Management_Ref { get; } = "No_Files_Management_Ref";
        public static string User_cannot_be_added { get; } = "User_cannot_be_added";
        public static string Contact_alreary_in_list { get; } = "Contact_alreary_in_list";
        public static string Exact_partner_profilename_required1 { get; } = "Exact_partner_profilename_required1";
        public static string Exact_partner_profilename_required2 { get; } = "Exact_partner_profilename_required2";
        public static string Add_first_contact { get; } = "Add_first_contact";
        public static string File_reference_not_save { get; } = "File_reference_not_save";
        public static string No_picture_to_upload { get; } = "No_picture_to_upload";
        public static string Settings_loading_message1 { get; } = "Settings_loading_message1";
        public static string Settings_loading_message2 { get; } = "Settings_loading_message2";
        public static string No_file_found { get; } = "No_file_found";
        public static string Mark_as_not_read { get; } = "Mark_as_not_read";
        public static string Mark_as_read { get; } = "Mark_as_read";
        public static string File_missing_local_and_server { get; } = "File_missing_local_and_server";
        public static string Impossible_to_save_the_audio_record { get; } = "Impossible_to_save_the_audio_record";
        public static string The_note_is_mandatory { get; } = "The_note_is_mandatory";
        public static string Record_audio_first { get; } = "Record_audio_first";
        public static string There_is_no_cache_audio_record { get; } = "There_is_no_cache_audio_record";
        public static string Required_audio_record_permission { get; } = "Required_audio_record_permission";
        public static string User_choosed { get; } = "User_choosed";
        public static string No_data_to_select { get; } = "No_data_to_select";
        public static string Private_publication_constraint1 { get; } = "Private_publication_constraint1";
        public static string Private_publication_constraint2 { get; } = "Private_publication_constraint2";
        public static string Public { get; } = "Public";
        public static string Private { get; } = "Private";
        public static string Private_publication_constraint3 { get; } = "Private_publication_constraint3";
        public static string Private_publication_constraint4 { get; } = "Private_publication_constraint4";
        public static string Private_publication_constraint5 { get; } = "Private_publication_constraint5";
        public static string Your_publication_will_be { get; } = "Your_publication_will_be";
        public static string Filter_error { get; } = "Filter_error";
        public static string Selected_notification_error { get; } = "Selected_notification_error";
        public static string Share_question { get; } = "Share_question";
        public static string User_reference_not_found { get; } = "User_reference_not_found";
        public static string Connection_To_FLK_Server_Failed { get; } = "Connection_To_FLK_Server_Failed";
        #endregion

        #region LoginExchange
        public static string Error_Creation_Auth_User_Log { get; } = "Error_Creation_Auth_User_Log";
        public static string Wrong_User { get; } = "Wrong_User";
        #endregion

        #region MainFlyoutDetail
        public static string Access_Control_Management { get; } = "Access_Control_Management";
        public static string Legal_notice { get; } = "Legal_notice";
        public static string here { get; } = "here";
        public static string Copyright { get; } = "Copyright";
        public static string terms_of_use1 { get; } = "terms_of_use1";
        public static string terms_of_use2 { get; } = "terms_of_use2";
        public static string LabelText1_MainFlyoutDetail { get; } = "LabelText1_MainFlyoutDetail";
        public static string LabelText2_MainFlyoutDetail { get; } = "LabelText2_MainFlyoutDetail";
        public static string LabelText3_MainFlyoutDetail { get; } = "LabelText3_MainFlyoutDetail";
        public static string LabelText4_MainFlyoutDetail { get; } = "LabelText4_MainFlyoutDetail";
        public static string LabelText5_MainFlyoutDetail { get; } = "LabelText5_MainFlyoutDetail";
        public static string up_to_date { get; } = "up_to_date";
        public static string Menu { get; } = "Menu";
        public static string Alert_Language_Choice { get; } = "Alert_Language_Choice";
        public static string Logout { get; } = "Logout";
        public static string Logout_Completed { get; } = "Logout_Completed";
        public static string Need_Authorization { get; } = "Need_Authorization";
        public static string Redirect_ToAuthorization_Page { get; } = "Redirect_ToAuthorization_Page";
        public static string Register { get; } = "Register";
        public static string Register_First_Account { get; } = "Register_First_Account";
        public static string Current_Version_Update { get; } = "Current_Version_Update";
        public static string Application_closing { get; } = "Application_closing";
        public static string Home { get; } = "Home";
        public static string Admin_Panel { get; } = "Admin_Panel";
        public static string Tutorials { get; } = "Tutorials";
        public static string Social_Network { get; } = "Social_Network";
        public static string Redirection_In_Progress { get; } = "Redirection_In_Progress";
        public static string Create_account { get; } = "Create_account";
        public static string FLK_Legal_notice { get; } = "FLK_Legal_notice";
        public static string FLK_Copyright { get; } = "FLK_Copyright";
        #endregion

        #region ReferenceGenerated
        public static string and { get; } = "and";
        public static string at { get; } = "at";
        public static string because { get; } = "because";
        #endregion

        #region SaveOnlineReport
        public static string Open_The_Online_Report { get; } = "Open_The_Online_Report";
        public static string Open_Both_Online_Report { get; } = "Open_Both_Online_Report";
        #endregion

        #region ChatServices
        public static string ExtraData_ReadStatus_SuccessPost { get; } = "ExtraData_ReadStatus_SuccessPost";
        public static string ExtraData_ReadStatus_FailedPost { get; } = "ExtraData_ReadStatus_FailedPost";
        #endregion

        #endregion

        #endregion

        #region Translate functions

        #region For language choice
        public static string LanguageSet { get; set; }
        public static List<string> LanguageSupported { get; set; }
        #endregion

        #region Forbidden characters
        public static List<string> GeneratedReference_Forbidden_fr { get; set; } = new List<string>();
        public static List<string> GeneratedReference_Forbidden_es { get; set; } = new List<string>();
        public static List<string> GeneratedReference_Forbidden_de { get; set; } = new List<string>();
        public static List<string> GeneratedReference_Forbidden_it { get; set; } = new List<string>();
        public static List<string> GeneratedReference_Forbidden_en { get; set; } = new List<string>();
        #endregion

        #region For GeneratedReference_Forbidden
        public static bool GetReferenceForbiddenList_Status()
        {
            bool listAreEmpty = false;
            int countEmpty = 0;

            if (GeneratedReference_Forbidden_en.Count == 0)
                countEmpty++;
            if (GeneratedReference_Forbidden_fr.Count == 0)
                countEmpty++;
            if (GeneratedReference_Forbidden_es.Count == 0)
                countEmpty++;
            if (GeneratedReference_Forbidden_de.Count == 0)
                countEmpty++;
            if (GeneratedReference_Forbidden_it.Count == 0)
                countEmpty++;

            if (countEmpty > 0)
                listAreEmpty = true;

            return listAreEmpty;
        }
        #endregion

        #endregion
    }
}
