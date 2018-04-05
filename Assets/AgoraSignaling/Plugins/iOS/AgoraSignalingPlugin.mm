#import <Foundation/Foundation.h>
#import "AgoraSignaling-Swift.h"

extern "C" {
    
    void initialize(const char *appId,const char *gameObjectName)
    {
        AgoraSignaling *agoraSig = AgoraSignaling.sharedManager;
        [agoraSig initializeWithAppId:[NSString stringWithUTF8String:appId] gameObjectName:[NSString stringWithUTF8String:gameObjectName]];
    }
    
    void login(const char *account)
    {
        AgoraSignaling *agoraSig = AgoraSignaling.sharedManager;
        [agoraSig loginWithAccount:[NSString stringWithUTF8String:account]];
    }
    
    void channelJoin(const char* channelName)
    {
        AgoraSignaling *agoraSig = AgoraSignaling.sharedManager;
        [agoraSig channelJoinWithChannelName:[NSString stringWithUTF8String:channelName]];
    }
    
    void sendChannelMessage(const char* message, const char* msgID)
    {
        AgoraSignaling *agoraSig = AgoraSignaling.sharedManager;
        [agoraSig sendChannelMessageWithMessage:[NSString stringWithUTF8String:message] msgID:[NSString stringWithUTF8String:msgID]];
    }
    
    void sendInstantMessage(const char* account,const char* message, const char* msgID)
    {
        AgoraSignaling *agoraSig = AgoraSignaling.sharedManager;
        [agoraSig sendInstantMessageWithAccount:[NSString stringWithUTF8String:account] message:[NSString stringWithUTF8String:message] msgID:[NSString stringWithUTF8String:msgID]];
    }
    
    void channelLeave()
    {
        AgoraSignaling *agoraSig = AgoraSignaling.sharedManager;
        [agoraSig channelLeave];
    }
    
    void logout()
    {
        AgoraSignaling *agoraSig = AgoraSignaling.sharedManager;
        [agoraSig logout];
    }
}

