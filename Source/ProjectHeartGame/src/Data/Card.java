/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Data;

import java.util.ArrayList;
import java.util.Random;

/**
 *
 * @author TienPhan
 */
public class Card {

   public static final int NUM_OF_FACE = 13;// Qui định 1 nước gồm có 13 lá.
   public static final int NUM_OF_CARD = 52; // Qui định số lá bài của một bộ là 52 lá
   public static final int FACE_2 = 0;   // Qui định con bài 2 = trọng số là 0: để sử lý con 2 chuồn(con thấp nhất)
   public static final int FACE_QUEEN = 10;//Qui đinh con bài Q = trọng số là 10 để sử lý con Đầm bích: trừ 13
   public static final int FACE_ACE = 12;// Qui định con bài Ace = trọng số là 12 để sử lý (con cao nhất)
   // Cho biết 4 nước trong lá bài
   public static final int SUIT_SPADE = 0;   //Bích
   public static final int SUIT_CLUB = 1;    //Chuồn
   public static final int SUIT_DIAMOND = 2;   //Rô
   public static final int SUIT_HEART = 3;  //Cơ
   public static final String PICTURES_FOLDER = "resources/"; //Folder chứa các con bài
   public static final String PICTURES_EXTEND = ".png"; // Đuôi mở rộng của con bài
   public static final String BACK_PICTURE = "resources/MatSap.png"; // Mặt up của con bài
   public static final String[] Face = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"}; // Đại diện cho các con bài
   public static final String[] Suit = {"SPADE", "CLUB", "DIAMOND", "HEART"};// Đại diện cho các nước khác nhau
   private int face; // Con bài thứ mấy trong bộ bài
   private int suit; // Loại bài gì: Spade, club, diamond, heart

   /*
    * Khởi tạo bộ bài
    * face: con thứ mấy trong bộ bài
    * suit: nước nào
    */
   public Card(int face, int suit) {
      this.face = face;
      this.suit = suit;
   }

   /*
    * Lấy ra thứ tự trong bộ bài.
    */
   public int getFace() {
      return this.face;
   }

   /*
    * Lấy ra nước của bộ bài
    */
   public int getSuit() {
      return this.suit;
   }

   /*
    * Gán giá trị của một con bài
    */
   public void setFace(int face) {
      this.face = face;
   }

   /*
    * gán giá trị: là nước
    */
   public void setSuit(int suit) {
      this.suit = suit;
   }

   /*
    * Lấy ra tên một lá bài bất kì// toString
    */
   public String getNameCard() {
      return (" " + Face[this.face] + Suit[this.suit]);
   }

   /*
    * Kiểm tra coi hai lá bài có giống nhau không// equals
    */
   public boolean equalsCard(Card c) {
      if (this.face == c.getFace() && this.suit == c.getSuit()) {
         return true;
      }
      return false;
   }
   /*
    * kiểm tra 1 con bài bất kỳ có phải là 2 chuồn hay không
    */

   public boolean isTwoClub() {
      if (this.equalsCard(new Card(FACE_2, SUIT_CLUB))) {
         return true;
      }
      return false;
   }

   /*
    * Kiểm tra coi một lá bài có phải là nước Cơ hay không
    */
   public boolean isHeart() {
      if ((this.suit == SUIT_HEART)) {
         return false;
      }
      return false;
   }

   /*
    * Kiểm tra xem một con có phải là con Đầm Bích không: để sử lý -13 điểm
    */
   public boolean isQueenSpade() {
      if (this.equalsCard(new Card(FACE_QUEEN, SUIT_SPADE))) {
         return true;
      }
      return false;
   }

   /*
    * Kiểm tra xem 1 lá bài (this) có lớn hơn một lá bài c cùng nước hay không
    */
   public boolean isGreatThan(Card c) {
      if (c.getSuit() == suit) {
         if (face > c.getFace()) {
            return true;
         }
         return false;
      }
      return false;
   }

   /*
    * Kiểm tra xem nó có nằm trong phạm vi 13 là bài không.
    * Nếu đúng: ta trả về một kiểu String: là chuổi một con bài và đường dẫn
    * Nếu sai: ta trả về "Invalid"
    */
   public String creatIconFile() {
      if (face > FACE_ACE || face < FACE_2 || suit > SUIT_HEART || suit < SUIT_SPADE) {
         return ("Invalid");
      }
      return (PICTURES_FOLDER + Face[face] + Suit[suit] + PICTURES_EXTEND);
   }

   /*
    * Tạo ra danh sách các con bài:
    *    Thiết lập một bộ bài. Xong rồi trộn các con bài lại với nhau.
    */
   public static ArrayList<Card> creatListCard() {
      //Tạo ra các bộ bài
      ArrayList<Card> listNumberCard = new ArrayList<Card>(NUM_OF_CARD); //listNumberCard = 52 lá
      for (int indexCard = 0; indexCard < NUM_OF_CARD; indexCard++) {
         int face = indexCard % NUM_OF_FACE;//face = [0-12]
         int suit = indexCard / NUM_OF_FACE;//suit = [0-3]
         Card cardTempl = new Card(face, suit);
         listNumberCard.add(cardTempl);
      }

      //sau đó random chúng đi
      Random randomCard = new Random();
      for (int indexCardCurrent = 0; indexCardCurrent < NUM_OF_CARD; indexCardCurrent++) {//[0-52]
         int indexCardTemp = randomCard.nextInt(NUM_OF_CARD);
         if (indexCardTemp != indexCardCurrent) {
            Card cardTemp = listNumberCard.get(indexCardCurrent);
            listNumberCard.set(indexCardCurrent, listNumberCard.get(indexCardTemp));
            listNumberCard.set(indexCardCurrent, cardTemp);
         }
      }
      return listNumberCard;
   }
}
