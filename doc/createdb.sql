SE [hotdog]
GO
/****** Object:  Table [dbo].[FavoriteHotDog]    Script Date: 3/24/2015 6:39:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FavoriteHotDog](
	[ProfileID] [numeric](9, 0) NOT NULL,
		[HotDogID] [numeric](9, 0) NOT NULL,
		 CONSTRAINT [PK_FavoriteHotDog] PRIMARY KEY CLUSTERED 
		 (
		 	[ProfileID] ASC,
				[HotDogID] ASC
				)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
				) ON [PRIMARY]

				GO
				/****** Object:  Table [dbo].[HotDog]    Script Date: 3/24/2015 6:39:41 PM ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				SET ANSI_PADDING ON
				GO
				CREATE TABLE [dbo].[HotDog](
					[HotDogID] [numeric](9, 0) IDENTITY(10,1) NOT NULL,
						[Name] [varchar](255) NOT NULL,
							[LastAte] [datetime] NOT NULL,
								[LastPlaceAte] [varchar](255) NOT NULL,
								 CONSTRAINT [PK_HotDog] PRIMARY KEY CLUSTERED 
								 (
								 	[HotDogID] ASC
									)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
									) ON [PRIMARY]

									GO
									SET ANSI_PADDING OFF
									GO
									/****** Object:  Table [dbo].[Profile]    Script Date: 3/24/2015 6:39:41 PM ******/
									SET ANSI_NULLS ON
									GO
									SET QUOTED_IDENTIFIER ON
									GO
									SET ANSI_PADDING ON
									GO
									CREATE TABLE [dbo].[Profile](
										[ProfileID] [numeric](9, 0) NOT NULL,
											[Name] [varchar](255) NOT NULL,
												[Bio] [varchar](3000) NOT NULL,
													[HotDogID] [numeric](9, 0) NULL,
														[Picture] [varchar](3000) NULL,
														 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
														 (
														 	[ProfileID] ASC
															)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
															) ON [PRIMARY]

															GO
															SET ANSI_PADDING OFF
															GO
															ALTER TABLE [dbo].[FavoriteHotDog]  WITH CHECK ADD  CONSTRAINT [FK_FavoriteHotDog_HotDog] FOREIGN KEY([HotDogID])
															REFERENCES [dbo].[HotDog] ([HotDogID])
															GO
															ALTER TABLE [dbo].[FavoriteHotDog] CHECK CONSTRAINT [FK_FavoriteHotDog_HotDog]
															GO
															ALTER TABLE [dbo].[FavoriteHotDog]  WITH CHECK ADD  CONSTRAINT [FK_FavoriteHotDog_Profile] FOREIGN KEY([ProfileID])
															REFERENCES [dbo].[Profile] ([ProfileID])
															GO
															ALTER TABLE [dbo].[FavoriteHotDog] CHECK CONSTRAINT [FK_FavoriteHotDog_Profile]
															GO

