create table AWBStatus(
 awb_number int IDENTITY(698700,1) NOT NULL,
 status_type int NOT NULL,
 sender varchar(60),
 reciever varchar(60) NOT NULL
 PRIMARY KEY(awb_number),
 FOREIGN KEY (status_type) REFERENCES Status(status_type)
)


create table Status(
 status_type int NOT NULL,
 status_value varchar(60) NOT NULL,
 PRIMARY KEY(status_type),

)

insert into Status Values(1,'Picked up by Courier')

insert into Status Values(2,'In Transit')

insert into Status Values(3,'Reached to your Nearest hub')

insert into Status Values(4,'Out for delivery')

insert into Status Values(5,'Customer Not available')

insert into Status Values(6,'Return to seller')

insert into Status Values(7,'Delivered')


insert into AWBStatus Values (1,'Gaurav, Bangalore-560066','Ravi, 110001')

insert into AWBStatus Values (7,'Preethi, Chennai','Denver, Amsterdem')

/* Join to get the proper status value */
select awb_number, status_value, sender, reciever from [Logistics].[dbo].[AWBStatus] as t1 
inner join [Logistics].[dbo].[Status] as t2 
on t1.status_type = t2.status_type  
where awb_number=698700
