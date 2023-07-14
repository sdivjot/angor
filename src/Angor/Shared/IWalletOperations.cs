using Angor.Shared.Models;
using Blockcore.Consensus.TransactionInfo;
using Blockcore.NBitcoin;
using Blockcore.Networks;

namespace Angor.Shared;

public interface IWalletOperations
{
    string GenerateWalletWords();
    Task<OperationResult<Transaction>> SendAmountToAddress(WalletWords walletWords, SendInfo sendInfo);
    AccountInfo BuildAccountInfoForWalletWords(WalletWords walletWords);
    Task UpdateDataForExistingAddressesAsync(AccountInfo accountInfo);
    Task UpdateAccountInfoWithNewAddressesAsync(AccountInfo accountInfo);
    Task<(string address, List<UtxoData> data)> FetchUtxoForAddressAsync(string adddress);
    List<UtxoDataWithPath> FindOutputsForTransaction(long sendAmountat, AccountInfo accountInfo);
    Task<IEnumerable<FeeEstimation>> GetFeeEstimationAsync();
    decimal CalculateTransactionFee(SendInfo sendInfo,AccountInfo accountInfo, long feeRate);
    (List<Coin>? coins, List<Key> keys) GetUnspentOutputsForTransaction(WalletWords walletWords, List<UtxoDataWithPath> utxoDataWithPaths);

    Transaction AddInputsAndSignTransaction(Network network, string changeAddress, Transaction transaction,
        WalletWords walletWords, List<UtxoDataWithPath> utxoDataWithPaths,
        FeeEstimation feeRate);

    Task<OperationResult<Transaction>> PublishTransactionAsync(Network network,
        Transaction signedTransaction);
}