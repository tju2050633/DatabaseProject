INSERT INTO Student_Staff(student_staff_id, name) VALUES('1', 'test1');
INSERT INTO Student_Staff(student_staff_id, name) VALUES('2', 'test2');
INSERT INTO Student_Staff(student_staff_id, name) VALUES('3', 'test3');

INSERT INTO Account(account_id, password, account_name, join_time, points, student_staff_id)
VALUES('1', '123', 'test', TIMESTAMP'2023-07-04 00:30:00', 0, '3');






COMMIT;