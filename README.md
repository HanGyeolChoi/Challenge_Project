# Challenge_Project
 꾸준실습 프로젝트

 개발 목표:

 vampire survivor류 게임 - brotato 

 와이어 프레임 :

 https://www.figma.com/board/PSeaCS7bHl8vNPEqKfjobb/Untitled?node-id=0-1&node-type=canvas&t=rvjxPVD55cY2tMdg-0

 개발 기간 :

 2024. 11. 04 ~
			

 1주차 진행 상황:
 
 와이어 프레임 작성

 각 Manager들을 싱글턴으로 만들기 위해 generic을 활용한 싱글턴 제작 - Manager/Singleton.cs
 
 Player Input system 구현 - wasd로 움직임, 마우스 방향으로 에임(옵션 추가 예정) - Player/PlayerController.cs
 플레이어의 스탯들을 저장하는 클래스 - PlayerStats.cs
 
 각 무기마다 동작하는 코드 구현 중 - Weapons/WeaponController.cs
 무기 데이터를 ScriptableObject로 저장 예정 - WeaponSO.cs
 
 소유 아이템과 무기 데이터를 저장하는 DataManager 구현 예정 - Manager/DataManager.cs