using MediatR;

namespace MediatR_Pattern.Notification
{
    public  record ProductAddedNotification(Product Product): INotification;
   
}
