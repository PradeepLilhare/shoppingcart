using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDataModel.CommonUtility
{
    public class CError
    {

        public enum ErrorType
        {
            Success = 0,
            Fail = 1,
            UserNameAlreadyExists = 2,
            EmailAlreadyExists = 3,
            ContactNumberAlreadyExists = 4,
            ErrorReadingFormVariables = 5,
            StoreProcedureFailed = 6,
            MailSentSuccessfully = 7,
            MailSendingFailed = 8,
            PurchaseListNotFound = 9,
            SOAPException = 10,
            AirwayBillGenerationFailed = 11,
            SalesCodeAlreadyExists = 12,
            SalesCodeNotExists = 13,
            EmployeeIdAlreadyExists = 14,
            PasswordDoesNotExists = 15,
            AnnexureExists = 16,
            InvoiceNumberExists = 17,
            TrackingSOAPError = 18,
            TrackingError = 19,
            OrderAlreadyCancelled = 20,
            OrderAlreadyInProcess = 21,
            InsufficientCreditBalance = 22,
            NoDataExists = 23,
            MultipleCommssions = 24,
            ErrorGeneratingReplacementChallan = 25,
            ReverseAirwayBillGenerationFailed = 26,
            NotApplicableServiceArea = 27,
            ErrorGeneratingCreditNote = 28,
            ErrODAPinCode = 29,
            ValidPinCode = 30,
            ProductSlabInputError = 31,
            EmailNotExists = 32,
            ErrorGeneratingPdf = 33,
            ShippingAddressAlreadyDeleted = 34,
            SessionExpired = 35,
            InvoiceGeneratedAlready = 36,
            ProductStateTaxIsZero = 37,
            OrderValueLessThanRequired = 38,
            BlueDartAWBFailed = 39,
            AlreadyRegisteredUser = 40,
            UserNotExists = 41,
            DeliveryPersonDeviceIdExists = 42,
            OrderAlreadyDelivered = 43,
            ErrorInXlsFile = 44,
            HSCodeLinkedToProduct = 45,
            KYCDocsUploaded = 46,
            KYCNotUploadedButFirstOrder = 47,
            KYCNotUploadedButPlacedFirstOrder = 48
        }
    }
}