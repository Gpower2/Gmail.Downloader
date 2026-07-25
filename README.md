# Gmail.Downloader

An open-source, secure Windows desktop application built with C# and the .NET framework designed to download, archive, and back up your Gmail history directly to your local machine.

Unlike cloud-based backup utilities, **Gmail.Downloader** operates entirely client-side. Your emails, account credentials, and authentication tokens never leave your computer, ensuring complete privacy and control over your data.

## 🚀 Features

* **100% Local Execution:** No external servers, no cloud tracking, and zero data collection.
* **Secure OAuth 2.0 Authentication:** Logs directly into Google using official, encrypted browser authentication.
* **Full Mailbox Archiving:** Downloads email messages, metadata, and attachments securely to folders you designate.
* **Open Source:** Transparent codebase allowing you to audit exactly how your personal data is handled.

---

## 🛠️ Prerequisites

* **Operating System:** Windows 10 / Windows 11
* **Runtime:** [.NET Desktop Runtime](https://dotnet.microsoft.com/download) (Ensure you have the appropriate version installed to run the application executable).

---

## 🔑 Setup & Google Cloud Configuration

Because Gmail access is highly restricted by Google, open-source desktop apps cannot safely embed a shared global API key without hitting strict user caps or creating security risks. 

To use this app, **you must generate your own free Google Cloud credentials**. It takes less than 5 minutes:

### 1. Create a Google Cloud Project
1. Go to the [Google Cloud Console](https://console.cloud.google.com/) and sign in with your Google account.
2. Click the project dropdown in the top-left corner and click **New Project**. Name it `GmailDownloader` and click **Create**.

### 2. Enable the Gmail API
1. In the left-side menu, navigate to **APIs & Services** > **Library**.
2. Search for **Gmail API**, click on it, and click **Enable**.

### 3. Configure the OAuth Consent Screen
1. Go to **APIs & Services** > **OAuth consent screen** (or **Audience** in the new layout).
2. Set the User Type to **External** and fill out the basic application details (App name, user support email).
3. Under **Publishing Status**, switch your project from **Testing** to **Production**. *(This ensures your login session doesn't expire every 7 days).*
4. **Data Access / Scopes:** Add the `gmail.readonly` scope so the app can fetch your messages.

### 4. Create and Download Credentials
1. Go to **APIs & Services** > **Credentials**.
2. Click **+ Create Credentials** at the top and select **OAuth client ID**.
3. Set the Application Type to **Desktop app**, give it a name, and click **Create**.
4. Click the **Download JSON** icon on the far right of your newly created client ID. Rename this downloaded file to `client_secret.json`.

---

## 💻 How to Use

1. Download the latest release of **Gmail.Downloader** from the [Releases](https://github.com/Gpower2/Gmail.Downloader/releases) section.
2. Place your generated `client_secret.json` file into the same directory as the `GmailDownloader.exe` executable.
3. Launch `GmailDownloader.exe`.
4. Click **Login / Authorize**. This will launch your default web browser.
5. Log in with your Google account. *(Because you generated your own keys, you will see a "Google hasn't verified this app" warning. Click **Advanced** > **Go to GmailDownloader (unsafe)** to approve your own project).*
6. Return to the desktop app, choose your destination folder, and begin your download!

---

## 🔒 Privacy & Security

Gmail.Downloader adheres strictly to Google's Limited Use policy requirements. 
* The application only requests read access (`gmail.readonly`) required to perform data archiving.
* Downloaded emails and OAuth tokens are stored exclusively on your local hard drive.
* For a detailed legal breakdown, please review our [Privacy Policy](PRIVACY.md).

---

## 🤝 Contributing

Contributions, bug reports, and feature requests are welcome! Feel free to open an issue or submit a pull request if you want to help improve the tool.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📄 License

Distributed under the [MIT License](LICENSE). See `LICENSE` for more information.
