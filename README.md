# bat_invisible_cs_scripts
## 概要
- BAT INVISIBLEに使用されているC# スクリプト.

## 変更から反映までの流れ
今まで（2021/12/25あたり）discord上でコードを送り合ってunityに反映、動作確認を行っていたが、これはお互い負担が大きいのとどれが最新のコードか追えなくなってしまうので、今後はこのやりとりをgithubベースでやるようにします！　その際の流れについて説明します。

### githubを使ったシステム開発の流れ
その前に、githubの機能紹介も兼ねて、githubを使うとどういう開発の流れになるのか説明します。

1. **issueを立てる** ：githubにはissueと呼ばれる機能があります。ざっくりいうと、これから取り組むべき開発項目がまとまったTODOリストです。 開発者（山岸）は何かする前にまずこのissueを作成し、ここにあることのどれかに取り組むことになります。 とはいえ、issueは本当に取り組むべきことのほかに、やってみたいことを書いたり、あるいはシステムとは直接的には関係しないリサーチ項目とその結果などを一時的にまとめたりに使ったり、割と用途が多義的だったりします。 中でも、「相談」ラベルがついたものは実装するかどうか迷ってることだったりするので、相談ラベルがついているissueは浦田ちゃんもみてあげてください。（相談ラベルがついたissueを作った時はdiscordでリマインドするので定期的にみたりする必要はないです）
<img width="1440" alt="スクリーンショット 2021-12-25 16 42 01" src="https://user-images.githubusercontent.com/47634358/147380567-78bcc7e4-ca15-404b-8018-3a5748acccbb.png">

2. **issueを選択し実装、完了したらプルリクエストを作成** :実装後、いきなり最新版としてgithub上のファイルを更新することはありません。バグが含まれていないかを実機で確認する必要があります。そこで、実機で確認すべき、暫定の更新情報をgithubに提出し、浦田ちゃんによる実機での確認を待ちます。この確認待ちの更新情報を、**プルリクエスト**と呼びます。
3. **実機での確認ができた場合, マージする** :バグが取り除かれ、所望の機能が実装できていることが確認された場合のみ最新版としてgithubのファイルを更新します。この時、既存のコードに変更を加えたコードを合体させることを**マージ**と呼びます。

### 本題：実機テストの方法
本題。実機テストすべきコードはどこにあるか？ 先程のプルリクエストにあります。 ここにあるコードを確認、うまくいったかどうかを山岸に教えてください。以下では、プルリクエストのコードの確認方法を説明します

プルリクエストのページにいくと、以下のような画面に出くわします。左が変更前の状態、右が変更後の状態。githubでは、このように「何が変わったのか？どのように変わったのか？」が一眼でわかるように、新旧２つのコードの変更点のみをピックアップして並べてくれます。 
<img width="1440" alt="スクリーンショット 2021-12-25 16 41 05" src="https://user-images.githubusercontent.com/47634358/147380483-3aedac69-0389-48e0-8357-f38e0a163702.png">


とはいえ、今欲しいのはコードの全体です。一部分だけ見れても困るので、このExpandボタンを押してコード全体を表示します。
<img width="336" alt="スクリーンショット 2021-12-25 16 41 20" src="https://user-images.githubusercontent.com/47634358/147380547-a64e6f54-ed2d-4750-ac1e-0f6288320dc6.png">


コードが表示されたら、いつも通り全体を選択して実機でテストしてください。
<img width="1440" alt="スクリーンショット 2021-12-25 16 41 36" src="https://user-images.githubusercontent.com/47634358/147380561-209b5eca-d5cd-4079-a386-fb8fecb58127.png">

動作確認ができたら、その旨をdiscord or github上でコメントしてください。うまく動かなかった場合はエラーメッセージや状況について併記してくれているとスムーズです。
また、バグの修正
