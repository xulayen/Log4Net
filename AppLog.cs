/*-----------------------------------------------------------------------------------------------------------
// Copyright (C) 2012 ��������(CCN)���޹�˾
// ��Ȩ���С�
//
// �ļ�����AppLog.cs
// �ļ�����������Ӧ�ó�����־��
// 
//
// ������ʶ��yhr20100914
//
// �޸ı�ʶ��
// �޸�������
//-----------------------------------------------------------------------------------------------------------*/

using System;
using System.Text;
using log4net;

namespace CcnMobile.Common
{
	/// <summary>
	/// ��־����
	/// </summary>
	public class AppLog
	{
		/// <summary>
		/// ��̬��
		/// </summary>
		private AppLog(){}
		private const String LOG_REPOSITORY = "Default"; // this should likely be set in the web config.
		private static ILog m_log;

        #region ��ʼ����־ϵͳ
        /// <summary>
		/// ��ʼ����־ϵͳ
		/// ��ϵͳ���п�ʼ��ʼ��
		/// Global.asax Application_Start��
		/// </summary>
		public static void Init()
		{
			log4net.Config.XmlConfigurator.Configure();
		}
        #endregion

        #region д����־1
        /// <summary>
		/// д����־1
		/// </summary>
		/// <param name="message">��־��Ϣ</param>
		/// <param name="messageType">��־����</param>
		public static void Write(String message, LogMessageType messageType)
		{
			DoLog(message, messageType, null, Type.GetType("System.Object"));
		}
        #endregion

        #region д����־2
        /// <summary>
		/// д����־2
		/// </summary>
		/// <param name="message">��־��Ϣ</param>
		/// <param name="messageType">��־����</param>
		/// <param name="type"></param>
		public static void Write(String message, LogMessageType messageType, Type type)
		{
			DoLog(message, messageType, null, type);
		}
        #endregion

        #region д����־3
        /// <summary>
		/// д����־2
		/// </summary>
		/// <param name="message">��־��Ϣ</param>
		/// <param name="messageType">��־����</param>
		/// <param name="ex">�쳣</param>
		public static void Write(String message, LogMessageType messageType, Exception ex)
		{
			DoLog(message, messageType, ex, Type.GetType("System.Object"));
        }
        #endregion

        #region д����־4
        /// <summary>
		/// д����־4
		/// </summary>
		/// <param name="message">��־��Ϣ</param>
		/// <param name="messageType">��־����</param>
		/// <param name="ex">�쳣</param>
		/// <param name="type"></param>
		public static void Write(String message, LogMessageType messageType, Exception ex,
		                         Type type)
		{
			DoLog(message, messageType, ex, type);
        }
        #endregion

        #region ����1
        /// <summary>
		/// ����1
		/// </summary>
		/// <param name="condition">����</param>
		/// <param name="message">��־��Ϣ</param>
		public static void Assert(bool condition, String message)
		{
			Assert(condition, message, Type.GetType("System.Object"));
        }
        #endregion

        #region ����1
        /// <summary>
		/// ����2
		/// </summary>
		/// <param name="condition">����</param>
		/// <param name="message">��־��Ϣ</param>
		/// <param name="type">��־����</param>
		public static void Assert(bool condition, String message, Type type)
		{
			if (condition == false)
				Write(message, LogMessageType.Info);
        }
        #endregion

        #region ������־
        /// <summary>
		/// ������־
		/// </summary>
		/// <param name="message">��־��Ϣ</param>
		/// <param name="messageType">��־����</param>
		/// <param name="ex">�쳣</param>
		/// <param name="type">��־����</param>
		private static void DoLog(String message, LogMessageType messageType, Exception ex,
		                          Type type)
		{
			m_log = LogManager.GetLogger(type);

			switch (messageType)
			{
				case LogMessageType.Debug:
					AppLog.m_log.Debug(message, ex);
					break;

				case LogMessageType.Info:
					AppLog.m_log.Info(message, ex);
					break;

				case LogMessageType.Warn:
					AppLog.m_log.Warn(message, ex);
					break;

				case LogMessageType.Error:
					AppLog.m_log.Error(message, ex);
					break;

				case LogMessageType.Fatal:
					AppLog.m_log.Fatal(message, ex);
					break;
			}
        }
        #endregion

        #region ��־����
        /// <summary>
		/// ��־����
		/// </summary>
		public enum LogMessageType
		{
			/// <summary>
			/// ���� ����1������Խ�߼���Խ��
			/// </summary>
			Debug,
			/// <summary>
            /// ��Ϣ ����2������Խ�߼���Խ��
			/// </summary>
			Info,
			/// <summary>
            /// ���� ����3������Խ�߼���Խ��
			/// </summary>
			Warn,
			/// <summary>
            /// ���� ����4������Խ�߼���Խ��
			/// </summary>
			Error,
			/// <summary>
            /// �������� ����5������Խ�߼���Խ�� 
			/// </summary>
			Fatal
        }
        #endregion
    }
}