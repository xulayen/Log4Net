# Log4Net
使用Log4Net日志 站点日志配置部分

  ``` html
  <log4net>
    <root>
      <priority value="ALL"/>
      <appender-ref ref="TraceAppender"/>
      <appender-ref ref="ConsoleAppender"/>
      <appender-ref ref="RollingFileAppender"/>
    </root>
    <appender name="TraceAppender" type="log4net.Appender.TraceAppender">
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%date [%thread] %-5level %logger [%property{NDC}] - %message%newline"/>
      </layout>
    </appender>
    <appender name="ConsoleAppender" type="log4net.Appender.ConsoleAppender">
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%date [%thread] %-5level %logger [%property{NDC}] - %message%newline"/>
      </layout>
    </appender>
    <!--滚动文件日志配置方式,按每天的日期生成日志文件-->
    <appender name="RollingFileAppender" type="log4net.Appender.RollingFileAppender,log4net">
      <param name="File" value="E:/AllLog/Backlog/Log"/>
      <param name="AppendToFile" value="true"/>
      <param name="RollingStyle" value="Composite"/>
      <param name="DatePattern" value="yyyyMMdd&quot;.log&quot;"/>
      <!--设置无限备份=-1 ，最大备份数为1000-->
      <maxSizeRollBackups value="10"/>
      <!--每个文件的最大10MB-->
      <maximumFileSize value="10MB"/>
      <!--名称是否可以更改,为false为可以更改-->
      <param name="StaticLogFileName" value="false"/>
      <lockingModel type="log4net.Appender.FileAppender+MinimalLock"/>
      <layout type="log4net.Layout.PatternLayout,log4net">
        <param name="ConversionPattern" value="%d [%t] %-5p %f %c - %m %n"/>
        <param name="Header" value=" ----------------------header--------------%n "/>
        <param name="Footer" value=" ----------------------footer--------------%n "/>
      </layout>
    </appender>
  </log4net>
  ```
