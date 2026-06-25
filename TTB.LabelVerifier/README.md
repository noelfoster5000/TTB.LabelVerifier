⭐ README.md — TTB Label Verifier
TTB Label Verifier
A WPF/MVVM application for extracting, validating, and comparing alcohol beverage label information for TTB compliance workflows.

📌 Overview
The TTB Label Verifier is a desktop tool designed to help analysts quickly evaluate alcohol beverage labels by:
	• Extracting key fields (Brand, ABV, Net Contents, Class/Type)
	• Validating the Government Warning for exact compliance
	• Comparing extracted values against expected application data
	• Processing multiple labels at once via Batch Mode
	• Presenting results in a clean, modern, card‑based UI
This project was built as part of a technical assessment and demonstrates:
	• MVVM architecture
	• Clean WPF UI design
	• Text extraction and comparison logic
	• Batch processing
	• Maintainable, testable code structure

🧱 Architecture
The application follows a clean MVVM structure:
Code
TTB.LabelVerifier│├── Core│   ├── Extraction│   ├── Comparison│   ├── Validation│   └── Models│├── UI│   ├── Views│   ├── ViewModels│   ├── Commands│   └── Styles│└── App.xaml / MainWindow.xaml
Key Components
Component	Responsibility
FieldExtractor	Parses raw label text into structured fields
FieldComparer	Compares extracted fields to expected values
GovernmentWarningValidator	Ensures exact match of required warning text
SingleCheckViewModel	Handles single‑label extraction & comparison
BatchCheckViewModel	Processes multiple labels separated by ---
RelayCommand	MVVM command implementation
ResultCard Style	Reusable card UI for polished output

🚀 Features
✔ Single Label Check
	• Paste full label text
	• Extract key fields
	• Validate Government Warning
	• Display results in a clean card layout
✔ Batch Label Processing
	• Paste multiple labels separated by ---
	• Extract fields for each label
	• Validate Government Warning per label
	• Auto‑name labels using Brand when available
	• Display results in scrollable card list
✔ Modern WPF UI
	• Navigation sidebar
	• Header bar
	• Status bar
	• Keyboard shortcuts (F1 = Single, F2 = Batch)
	• Card‑based results
	• Consistent spacing, colors, and typography


🛠️ Technologies Used
	• C# / .NET 6+
	• WPF
	• MVVM
	• ObservableCollection
	• RelayCommand
	• XAML Styles & Templates

📥 Installation & Running
1. Clone the repository									
	Code
    git clone https://github.com/yourusername/TTB.LabelVerifier.git

2. Open in Visual Studio
	• Requires Visual Studio 2022 or later
	• Requires .NET Desktop Development workload

3. Build & Run
Press F5 to launch the application.

🧪 Testing
The extraction, comparison, and validation logic is isolated in the Core project, making it easy to unit test.
Recommended test areas:
	• Brand extraction
	• ABV parsing
	• Net contents normalization
	• Class/Type detection
	• Government Warning exact match
	• Batch splitting logic

📌 Known Limitations
This prototype intentionally focuses on text‑based label verification.
Not included (but possible future enhancements):
	• OCR / image extraction
	• Producer name/address extraction
	• Country of origin detection
	• COLA integration
	• Machine learning models for classification

🔮 Future Enhancements
If expanded beyond the assessment, the following features would add significant value:
	• Drag‑and‑drop label images
	• OCR pipeline (Azure Cognitive Services or Tesseract)
	• Side‑by‑side comparison UI
	• CSV import/export for batch mode
	• Parallel processing for large batches
	• Error banners & validation messages
	• Dark mode

👤 Author
Noel Foster Springfield, IL C# / WPF / .NET Developer

📄 License
This project is provided as part of a technical assessment and is not licensed for production use.
