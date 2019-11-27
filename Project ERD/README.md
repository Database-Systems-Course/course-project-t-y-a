Database Project ERD

Add Project ERD and other related documents in this folder

Changes made:

Log 1 (21/11/2019):
- Removed the course_offer_year and semester attributes from Course.
- Added the above mentioned attributes to the Section entity.
- Changed the name of the entity 'Section' to 'Class'.

Log 2 (24/11/2019):
- Removed the relation of staff entity with events and department.
- Changed the name of entity 'Staff' to 'RO Staff'.
- Reason for the above changes is that previously the staff were adding courses and events and were also participating in events that created some complexity and confusion. Now our staff is only the RO staff that can handle the addition and deletion of courses and events which makes the system much more clearer and our focus is more towards the functionalities for the staff and faculty.
