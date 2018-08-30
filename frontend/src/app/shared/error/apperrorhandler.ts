import { ErrorHandler, Injector } from "@angular/core";
import { HttpErrorResponse } from "@angular/common/http";


/**
 * App error handler
 */
export class AppErrorHandler implements ErrorHandler {   
    // constructor(
    //   private injector: Injector,
    // ) {}

    handleError(error: Error | HttpErrorResponse) {        
        //const notificationService = this.injector.get(NotificationService);
        //const router = this.injector.get(Router);
    
        if (error instanceof HttpErrorResponse) {
        // Server error happened      
          if (!navigator.onLine) {
            // No Internet connection
             // if required we can implement application level logging or notification services like toast 
            //return notificationService.notify('No Internet Connection');
            console.log(`${error.status} - ${error.message}`);
          }
          // Http 
           // if required we can implement application level logging or notification services like toast 
         // return notificationService.notify(`${error.status} - ${error.message}`);
         console.log(`${error.status} - ${error.message}`);
        } else {
          // Client Error Happend     
          // if required we can implement application level logging or notification services like toast 
         // router.navigate(['/error'], { queryParams: {error: error} });
         console.error(error);
        }
        // Log the error anyway
        console.error(error);
      }
}
