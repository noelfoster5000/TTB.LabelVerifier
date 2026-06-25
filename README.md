# ⭐ TTB Label Verifier

A WPF/MVVM application for extracting, validating, and comparing alcohol beverage label information for TTB compliance workflows.

---

## 📌 Overview

The **TTB Label Verifier** is a desktop tool designed to help analysts quickly evaluate alcohol beverage labels by:

- Extracting key fields (Brand, ABV, Net Contents, Class/Type)
- Validating the Government Warning for exact compliance
- Comparing extracted values against expected application data
- Processing multiple labels at once via Batch Mode
- Presenting results in a clean, modern, card‑based UI

This project was built as part of a technical assessment and demonstrates:

- MVVM architecture  
- Clean WPF UI design  
- Text extraction and comparison logic  
- Batch processing  
- Maintainable, testable code structure  

---

## 🧱 Architecture
The application follows a clean MVVM structure:

```
TTB.LabelVerifier
│
├── Core
│   ├── Extraction
│   ├── Comparison
│   ├── Validation
│   └── Models
│
├── UI
│   ├── Views
│   ├── ViewModels
│   ├── Commands
│   └── Styles
│
└── App.xaml / MainWindow.xaml
```

## 🔑 Key Components

| Component | Responsibility |
|----------|----------------|
| **FieldExtractor** | Parses raw label text into structured fields |
| **FieldComparer** | Compares extracted fields to expected values |
| **GovernmentWarningValidator** | Ensures exact match of required warning text |
| **SingleCheckViewModel** | Handles single‑label extraction & comparison |
| **BatchCheckViewModel** | Processes multiple labels separated by `---` |
| **RelayCommand** | MVVM command implementation |
| **ResultCard Style** | Reusable card UI for polished output |

---

## 🚀 Features

### ✔ Single Label Check
- Paste full label text  
- Extract key fields  
- Validate Government Warning  
- Display results in a clean card layout  

### ✔ Batch Label Processing
- Paste multiple labels separated by `---`  
- Extract fields for each label  
- Validate Government Warning per label  
- Auto‑name labels using Brand when available  
- Display results in scrollable card list  

### ✔ Modern WPF UI
- Navigation sidebar  
- Header bar  
- Status bar  
- Keyboard shortcuts (F1 = Single, F2 = Batch)  
- Card‑based results  
- Consistent spacing, colors, and typography  

---

## 🛠️ Technologies Used

- C# / .NET 6+  
- WPF  
- MVVM  
- ObservableCollection  
- RelayCommand  
- XAML Styles & Templates  

---

## 📥 Installation & Running

## 🔗 Download
Download the latest compiled version from the Releases page:
https://github.com/noelfoster5000/TTB.LabelVerifier/releases

After downloading, extract the ZIP and run `TTB.LabelVerifier.exe`.





---

```
## ➡ Single Label Check
Use the Single screen to extract fields and validate the Government Warning.

```
Example Input:
SUNSET RIDGE DISTILLERY
Kentucky Straight Bourbon Whiskey
45% ALC./VOL. (90 PROOF)
750 mL

GOVERNMENT WARNING:
(1) According to the Surgeon General, women should not drink alcoholic beverages during pregnancy because of the risk of birth defects.
(2) Consumption of alcoholic beverages impairs your ability to drive a car or operate machinery, and may cause health problems.
```

---

## ➡ Batch Label Processing
Use the Batch screen to process multiple labels separated by ---.

```
Example Input:
SUNSET RIDGE DISTILLERY
45% ALC./VOL.
750 mL
---
BLUE HARBOR WINES
13.5% ALC./VOL.
750 ML
---
OLD TOM DISTILLERY
90 PROOF
750 ML
```
```

---




