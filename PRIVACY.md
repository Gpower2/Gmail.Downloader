# Privacy Policy for GmailDownloader

**Effective Date:** [July 2026]

GmailDownloader ("the Application") is an open-source Windows desktop application built to allow users to securely connect to their own accounts, download, and back up their email history locally. This Privacy Policy outlines how the Application accesses, processes, and handles user data, particularly information retrieved through Google API Services.

### 1. Information Collection and Access
GmailDownloader interacts directly with Google APIs to communicate with your Gmail account. Depending on your configuration, the Application requests permission to access specific OAuth scopes, such as:
* Reading email messages, metadata, and attachments (`gmail.readonly`).
* Modifying or managing labels if requested by your local settings.

**Important Client-Side Notice:** GmailDownloader is a standalone desktop application. 
* **No Server Architecture:** There are no backend servers, databases, analytical cloud systems, or remote tracking services connected to this software. 
* **No Developer Access:** The developer of GmailDownloader has absolutely no access to your Google credentials, authorization tokens, or downloaded email data. 

### 2. How Your Data is Used
All data retrieved via the Gmail API is processed strictly within your local machine environment. The data is used solely to execute the core function of the application: downloading and formatting your personal email archives into your designated local folders.
* Your data is never sold, leased, traded, or rented to third parties.
* Your data is never used for marketing, advertising, profiling, or targeted messaging.

### 3. Data Storage and Security
* **Authentication Tokens:** When you grant authorization, Google issues an OAuth 2.0 access and refresh token. These credentials are saved securely and exclusively on your local computer's local application storage.
* **Downloaded Contents:** All downloaded emails, attachments, and log histories are written directly to the file paths you specify on your personal hard drive.
* **Local Security:** Because no data leaves your machine, the security of your archived information relies entirely on your own local operating system security configurations. 

### 4. Google API Services User Data Policy Compliance (Limited Use)
GmailDownloader's use and transfer to any other app of information received from Google APIs will adhere to the [Google API Services User Data Policy](https://developers.google.com/terms/api-services-user-data-policy), including the Limited Use requirements.

### 5. Third-Party Sharing
Aside from establishing a secure, direct encrypted connection to official Google API endpoints to retrieve your mail, GmailDownloader does not share, transmit, or expose your data to any other third-party software, utilities, or external servers.

### 6. Policy Updates
This policy may be amended over time to accommodate updates to the application or evolving Google developer requirements. Any updates will be pushed transparently to the public GitHub repository.

### 7. Contact & Support
If you have questions about this application's data handling practices, please open a public issue on our repository or contact the developer directly at:
* **Email:** [arslanoglou.georgios@gmail.com]
* **Project Repository:** https://github.com/Gpower2/Gmail.Downloader
