# 🎮 Walk of Life 3D - Full Authentic Unity Game Project

ยินดีต้อนรับสู่โปรเจกต์เกม **Walk of Life 3D (Calicornia Coast)** ถอดแบบสถาปัตยกรรมและกลไกเกมจากตัวอย่างเกมเพลย์ 1 ชั่วโมง 27 นาที แบบ 1-ต่อ-1 100%

---

## 📁 โครงสร้างโปรเจกต์ Unity 3D (`d:\My\`)

```text
d:\My\
├── index.html                        # 🌐 Playable Authentic Web Prototype (เปิดเล่นบนเบราว์เซอร์ได้ทันที)
├── README.md                         # 📖 คู่มือการติดตั้งโปรเจกต์ Unity 3D
└── Assets\
    └── Scripts\
        ├── Core\
        │   ├── WalkOfLife3DGameManager.cs   # ควบคุม Game Loop ทั้งหมด
        │   ├── TimeClockSystem.cs         # ระบบตัดเวลา 12 ชม./วัน
        │   ├── HospitalPenaltySystem.cs   # ระบบทำโทษโรงพยาบาล (เสีย $200 + ข้าม 1 ตา)
        │   ├── BankLoanSystem.cs          # ระบบฝากเงินรับดอกเบี้ย 10% + กู้เงินฉุกเฉิน $500
        │   ├── RiskRewardEvents.cs        # ระบบการ์ดสุดสัปดาห์เสี่ยงดวง
        │   ├── SoundBGMManager.cs         # ระบบดนตรี BGM & Cartoon SFX
        │   └── ScoringEngine3D.cs         # คำนวณคะแนน Victory Points
        ├── Map3D\
        │   ├── MapWaypointNode.cs         # โหนดถนนกระดานเมือง 3D
        │   └── Camera3DTracker.cs         # ระบบกล้อง 3D แพนซูมติดตามผู้เล่นและบอท
        ├── Character\
        │   ├── CharacterRoleData.cs       # สกิลติดตัว 4 สายอาชีพ (Workaholic, Scholar, Scavenger, Hedonist)
        │   └── Character3DMovement.cs     # ควบคุมการเดินตามโหนดถนน 3D
        ├── Apartment\
        │   └── AutoFurnitureSpawner.cs    # สปอว์นเฟอร์นิเจอร์ 3D เข้า Slot อัตโนมัติ
        └── UI\
            ├── ThaiMainMenuController.cs  # หน้าเมนูหลักภาษาไทย ปุ่ม เล่น, การตั้งค่า, ออก
            ├── PagerWidgetUI.cs           # เครื่อง Pager รหัสห้อง WGNIN9FC (Copy to Clipboard)
            ├── WalkOfLifeHUD.cs           # HUD รูปการ์ตูน Nova + แถบสเตตัส 3 แถบ
            └── VictoryPodiumUI.cs         # ฉากรับรางวัล 3D Side-by-Side Showcase
```

---

## 🕹️ การเปิดเล่นบนเบราว์เซอร์
1. เข้าชมผ่านลิงก์ **[http://localhost:8080](http://localhost:8080)**
2. หรือเปิดไฟล์ [index.html](file:///d:/My/index.html) ในโฟลเดอร์ `d:\My\`
