show databases;




create database resilience;
create database auth;

ALTER DATABASE resilience
CHARACTER SET latin1
COLLATE latin1_general_cs;

SELECT DEFAULT_CHARACTER_SET_NAME, DEFAULT_COLLATION_NAME
FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'resilience';

drop database resilience;

use auth;
select * from users;
show tables;

select CURRENT_TIMESTAMP;
SET @@global.time_zone = '-3:00';
show tables;

select * from auth.users;

CREATE TABLE respondent_groups (
    id INT AUTO_INCREMENT NOT NULL,
    description VARCHAR(200) NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    active BOOL NOT NULL DEFAULT TRUE,
    PRIMARY KEY(id)
);


CREATE TABLE establishments (
    id INT AUTO_INCREMENT NOT NULL,
    name VARCHAR(200) NOT NULL,
    zip_code VARCHAR(8) NOT NULL,
    neighborhood VARCHAR(200) NOT NULL,
    street VARCHAR(200) NOT NULL,
    city VARCHAR(200) NOT NULL,
    state VARCHAR(2) NOT NULL,
    number VARCHAR(10) NOT NULl,
    complement VARCHAR(200),
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    active BOOL NOT NULL DEFAULT TRUE,
    PRIMARY KEY(id)
);

drop table questionnaires;

CREATE TABLE questionnaires (
    id INT AUTO_INCREMENT NOT NULL,
    id_respondent_group INT NOT NULL,
    description VARCHAR(256) NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    active BOOL NOT NULL DEFAULT TRUE,
    is_functionality_questionnaire BOOL NOT NULL DEFAULT FALSE,
    FOREIGN KEY (id_respondent_group) REFERENCES respondent_groups(id) ON DELETE RESTRICT ON UPDATE CASCADE,
    PRIMARY KEY(id)
);
drop table question_groups;
CREATE TABLE question_groups (
    id INT AUTO_INCREMENT NOT NULL,
    id_questionnaire INT NOT NULL,
    description VARCHAR(256) NOT NULL,
    question_group_order INT NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    active BOOL NOT NULL DEFAULT TRUE,
    FOREIGN KEY (id_questionnaire) REFERENCES questionnaires(id) ON DELETE RESTRICT ON UPDATE CASCADE,
    PRIMARY KEY(id)
);

drop table questions;

CREATE TABLE questions (
    id INT AUTO_INCREMENT NOT NULL,
    id_question_group INT NOT NULL,
    question_order INT NOT NULL,
    question TEXT NOT NULL,
    first_answer CHAR(3) DEFAULT 'Sim' NOT NULL,
    first_answer_note TINYINT,
    second_answer CHAR(3) DEFAULT 'Não' NOT NULL,
    second_answer_note TINYINT,
    third_answer VARCHAR(30),
    third_answer_note TINYINT DEFAULT NULL,
    additional_answer VARCHAR(256),
    additional_answer_note TINYINT DEFAULT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    active BOOL NOT NULL DEFAULT TRUE,
    FOREIGN KEY (id_question_group) REFERENCES question_groups(id) ON DELETE RESTRICT ON UPDATE CASCADE,
    PRIMARY KEY(id)
);

drop table establishment_questionnaires;

CREATE TABLE establishment_questionnaires (
    id INT AUTO_INCREMENT NOT NULL,
    id_establishment INT NOT NULL,
    id_questionnaire INT NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    active BOOL NOT NULL DEFAULT TRUE,
    FOREIGN KEY (id_establishment) REFERENCES establishments(id) ON DELETE RESTRICT ON UPDATE CASCADE,
    FOREIGN KEY (id_questionnaire) REFERENCES questionnaires(id) ON DELETE RESTRICT ON UPDATE CASCADE,
    PRIMARY KEY(id)
);

drop table answers;

CREATE TABLE answers (
    id INT AUTO_INCREMENT NOT NULL,
    id_establishment INT NOT NULL,
    id_question INT NOT NULL,
    unique_code VARCHAR(256) NOT NULL,
    question_one_answered BOOL,
    question_two_answered BOOL,
    question_three_answered BOOL,
    additional_question_answered BOOL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (id_question) REFERENCES questions(id) ON DELETE RESTRICT ON UPDATE CASCADE,
    FOREIGN KEY (id_establishment) REFERENCES establishments(id) ON DELETE RESTRICT ON UPDATE CASCADE,
    PRIMARY KEY(id)
);

select * from auth.users;

select * from questionnaires;
select * from respondent_groups;
select * from question_groups;
select * from questions;
select * from answers;

alter table questions drop column additional_answer_note;

select * from questionnaires;

select
    q.id as Id,
    q.id_respondent_group as RespondentGroupId,
    q.description as Description,
    q.active as Active
from questionnaires q;

select * from question_groups where id_questionnaire = 1;

select
    q.id as Id,
    q.id_respondent_group as RespondentGroupId,
    q.description as Description,
    q.active as Active
from establishment_questionnaires eq
    inner join questionnaires q on eq.id_questionnaire = q.id
where eq.id_establishment = 1;

SELECT `t`.`id`, `t`.`active`, `t`.`created_at`, `t`.`description`, `t`.`id_respondent_group`, `t`.`updated_at`, `t0`.`id`, `t0`.`active`, `t0`.`created_at`, `t0`.`description`, `t0`.`id_questionnaire`, `t0`.`question_group_order`, `t0`.`updated_at`, `t0`.`id0`, `t0`.`active0`, `t0`.`additional_answer`, `t0`.`additional_answer_note`, `t0`.`created_at0`, `t0`.`first_answer`, `t0`.`first_answer_note`, `t0`.`id_question_group`, `t0`.`question`, `t0`.`question_order`, `t0`.`second_answer`, `t0`.`second_answer_note`, `t0`.`third_answer`, `t0`.`third_answer_note`, `t0`.`updated_at0`
FROM (
    SELECT `q`.`id`, `q`.`active`, `q`.`created_at`, `q`.`description`, `q`.`id_respondent_group`, `q`.`updated_at`
    FROM `questionnaires` AS `q`
    WHERE (`q`.`id` = 1) AND EXISTS (
        SELECT 1
        FROM `question_groups` AS `q0`
        WHERE `q`.`id` = `q0`.`id_questionnaire`)
    LIMIT 1
) AS `t`
LEFT JOIN (
    SELECT `q1`.`id`, `q1`.`active`, `q1`.`created_at`, `q1`.`description`, `q1`.`id_questionnaire`, `q1`.`question_group_order`, `q1`.`updated_at`, `q2`.`id` AS `id0`, `q2`.`active` AS `active0`, `q2`.`additional_answer`, `q2`.`additional_answer_note`, `q2`.`created_at` AS `created_at0`, `q2`.`first_answer`, `q2`.`first_answer_note`, `q2`.`id_question_group`, `q2`.`question`, `q2`.`question_order`, `q2`.`second_answer`, `q2`.`second_answer_note`, `q2`.`third_answer`, `q2`.`third_answer_note`, `q2`.`updated_at` AS `updated_at0`
    FROM `question_groups` AS `q1`
    LEFT JOIN `questions` AS `q2` ON `q1`.`id` = `q2`.`id_question_group`
) AS `t0` ON `t`.`id` = `t0`.`id_questionnaire`
ORDER BY `t`.`id`, `t0`.`id`;

select
    q.id_respondent_group as IdRespondentGroup,
    q.description as Description,
    q.active as Active,
    qg.id_questionnaire as IdQuestionnaire,
    qg.description as Description,
    qg.question_group_order as QuestionGroupOrder,
    qg.active as Active,
    q2.id_question_group as IdQuestionGroup,
    q2.question_order as QuestionOrder,
    q2.question as QuestionDescription,
    q2.first_answer as FirstAnswer,
    q2.first_answer_note as FirstAnswerNote,
    q2.second_answer as SecondAnswer,
    q2.second_answer_note as SecondAnswerNote,
    q2.third_answer as ThirdAnswer,
    q2.third_answer_note as ThirdAnswerNote,
    q2.additional_answer as AdditionalAnswer,
    q2.additional_answer_note as AdditionalAnswerNote,
    q2.active as Active
from questionnaires q
    inner join question_groups qg on q.id = qg.id_questionnaire
    inner join questions q2 on qg.id = q2.id_question_group
where q.id = 1;

select * from respondent_groups;