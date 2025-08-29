# 🎮 Inventory System

안녕하세요! 개인과제에서 주어진 인벤토리를 구현해 봤습니다.  

- **Player 초기 정보** → `Resources/Character/Player` 프리팹 인스펙터에서 수정  
- **아이템 데이터** → `Resources/Item` 폴더 내 `ScriptableObject`  
- **UI 프리팹** → `Resources/UI` 폴더 (동적 생성 연습용, 일부 미완성)  

---

## 🏗 구조

### 🔧 싱글톤
- `GameManager`, `UIManager` → **SingletonMono** 클래스 상속  
- `SingletonMono` 내부에 싱글톤 생성 기능 내장 → 상속만으로 싱글톤 설정  
- `Awake`는 `virtual` → 상속받은 클래스에서 사용 시 `override` + `base.Awake()` 필요  

---

### 🖼 UIBase
- 모든 UI → 추상 클래스 **UIBase** 상속
- `OpenUI`, `CloseUI` 추상 메서드 → 반드시 구현 필요

---

### 📦 ItemData
- 아이템 데이터 → `ScriptableObject` 기반
- **ItemData**: 기본 정보
- **EquipItemData**: `ItemData` 상속 + 상세 정보
- **EItemType enum** → 장비 / 소모품 / 일반 아이템 등 확장 고려

| 타입             | 설명     |
| -------------- | ------ |
| **Equip**      | 장착 아이템 |
| **Consumable** | 소모품    |
| **Common**     | 일반 아이템 |

---

### 🧑 Character
- **Character**: 공통 필드 정의
- **Player**: `Character` 상속, 플레이어 전용
- Enemy 확장 가능성 고려
- 전투 시스템 시 → `IDamageable` 인터페이스로 확장

---

## 🖥 UI

### 📋 메인 메뉴
- `MainScene` 실행 시 표시
- **좌측**: `Player` 정보
- **우측**: `Status`, `Inventory` 버튼
- **우측 상단**: `Gold UI`
- `UpdateMainMenu` 실행 시 캐릭터 정보 갱신

---

### 📊 스테이터스
- 메인 메뉴 → `Status` 버튼 클릭 시 등장
- `Player`의 현재 스탯 표시
- `OpenUI` 시점에서 `UpdateStatus` 메서드 실행
- 닫기 버튼 → 스탯 UI 닫힘 + 메인 메뉴 버튼 재활성화

---

### 🎒 인벤토리
- 시작 시 슬롯 수만큼 **아이템 슬롯 자동 생성**
- `GameManager.Start()` → `SetData()` 실행 → 초기 아이템 7개 등록
- 인벤토리 열기 → 등록된 7개 아이템 표시

#### 슬롯 동작
- **슬롯 클릭** →
  - 아이템 존재 → 정보 UI + 장착 관리 UI 표시
  - 아이템 없음 → 정보 UI 닫힘
- **Equip 버튼** →
  - 슬롯에 `E` 아이콘 표시
  - Player 스탯 반영
- **UnEquip 버튼** →
  - 장착 해제 + 아이콘 제거
  - 장착되지 않은 아이템에 대해 `UnEquip` 시도 시 → `Debug.Log` 출력
- 다른 아이템 선택 후 `Equip` → 기존 장비 해제 + 새로운 장비 장착

#### 닫기 버튼
- 인벤토리 닫힘 + 메인 메뉴 버튼 재활성화
- 정보 UI가 열려 있어도 정상 닫기 가능

---

# 질문

## UIManager
- UI들을 UIBase 컬렉션으로 관리하려고 합니다.
  - 컬렉션을 List로 두는 것이 나을지, Dictionary로 두는 것이 나을까요?
  - Dictionary를 쓴다면 Key를 string 이름으로 두는 게 좋을지, enum 타입으로 두는 게 좋을지 궁금합니다.
- 각 UI가 생성될 때 스스로 UIManager 컬렉션에 등록되는 방식이 괜찮은지요?
- 전체 UI를 닫고 싶을 때는 컬렉션을 순회하며 CloseUI()를 실행하면 될까요?
- 한 번에 하나의 UI만 켜야 하는 경우, “전체 닫기 → 해당 UI만 열기” 방식이 일반적으로 쓰이나요?

---

## Player 장비
- 부위별 장비 장착을 구현하려고 합니다.
  - 장비를 타입별(Head, Body, Weapon 등)로 나누고, 타입별로 하나씩만 장착 가능하도록 하는 것이 보통인가요?
  - 장신구처럼 여러 개 장착 가능한 슬롯은 어떤 방식으로 관리하는 것이 좋을까요?
- Dictionary<장비타입, 장착아이템> 구조로 관리하는 방식이 적절한지 궁금합니다.

---

## Character 스탯

- Stat이라는 클래스를 따로 만들어 현재 수치, 최대 수치, 증감 로직 등을 넣는 방식이 괜찮을까요?
- 여러 스탯을 관리할 때
  - List<Stat>로 관리하는 것과
  - Dictionary<StatType, Stat>로 enum 키를 통해 접근하는 것 중 어떤 방법이 더 일반적일까요?
