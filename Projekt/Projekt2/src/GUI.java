import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.URL;
import java.net.URLConnection;
import java.util.*;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JButton;

import com.google.gson.*;
import com.google.gson.internal.LinkedTreeMap;
import com.google.gson.reflect.*;

public class GUI extends JFrame {

    private JButton pobierzApiButton;
    private JPanel panel1;
    private JLabel mainIcon;
    private JLabel tempDay1;
    private JLabel tempDay2;
    private JLabel tempDay3;
    private JLabel tempDay4;
    private JLabel tempDay5;
    private JLabel iconDay1;
    private JLabel iconDay2;
    private JLabel iconDay3;
    private JLabel iconDay4;
    private JLabel iconDay5;
    private JLabel location;
    private JLabel todayTemp;
    private JLabel todayHum;
    private JLabel todayWindSpeed;
    private JTextField textField1;
    private JTextField textField2;
    private JLabel appName;
    private JLabel todayPressure;

    public GUI(){
        setSize(770, 600);
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        setTitle("Weather Api");
        setContentPane(panel1);
        appName.setText("<html> Aplikacja pogodowa <br/> z prognoza na 5 dni </html>");
        setVisible(true);


        pobierzApiButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String[] weather;
                String lat = textField1.getText();
                String lon = textField2.getText();
                String coords = "lat=" + lat + "&lon=" + lon;
                String address = site + coords + apiKey;
                weather = callApi(address);
                location.setText(weather[0]);
                todayTemp.setText(weather[1]);
                todayHum.setText(weather[2]);
                todayWindSpeed.setText(weather[3]);
                todayPressure.setText(weather[4]);

                tempDay1.setText(weather[5]);
                tempDay2.setText(weather[6]);
                tempDay3.setText(weather[7]);
                tempDay4.setText(weather[8]);
                tempDay5.setText(weather[9]);

                ImageIcon[] images = new ImageIcon[8];
                images[0] = new ImageIcon("Sun1.jpg");
                images[1] = new ImageIcon("Clouds1.jpg");
                images[2] = new ImageIcon("Rain1.jpg");
                images[3] = new ImageIcon("Thunder1.jpg");
                images[4] = new ImageIcon("Sun2.jpg");
                images[5] = new ImageIcon("Clouds2.jpg");
                images[6] = new ImageIcon("Rain2.jpg");
                images[7] = new ImageIcon("Thunder2.jpg");

                if(Objects.equals(weather[10], "Clear")){
                    mainIcon.setIcon(images[4]);
                } else if(Objects.equals(weather[10], "Clouds")){
                    mainIcon.setIcon(images[5]);
                } else if(Objects.equals(weather[10], "Rain")){
                    mainIcon.setIcon(images[6]);
                } else {
                    mainIcon.setIcon(images[7]);
                }

                for(int i = 11; i < 16; i++){
                    int flag = -1;
                    if(Objects.equals(weather[i], "Clear")){
                        flag = 0;
                    } else if (Objects.equals(weather[i], "Clouds")) {
                        flag = 1;
                    } else if (Objects.equals(weather[i], "Rain")) {
                        flag = 2;
                    } else {
                        flag = 3;
                    }

                    if(i == 11){
                        iconDay1.setIcon(images[flag]);
                    } else if (i == 12) {
                        iconDay2.setIcon(images[flag]);
                    } else if (i == 13) {
                        iconDay3.setIcon(images[flag]);
                    } else if (i == 14) {
                        iconDay4.setIcon(images[flag]);
                    } else {
                        iconDay5.setIcon(images[flag]);
                    }
                }
            }
        });
    }

    public static void main(String args[]){

        GUI frame = new GUI();
    }

    public static String[] callApi(String address) {

        try {
            StringBuilder result = new StringBuilder();
            URL url = new URL(address);
            URLConnection conn = url.openConnection();
            BufferedReader rd = new BufferedReader(new InputStreamReader(conn.getInputStream()));
            String line;
            while((line = rd.readLine()) != null) {
                result.append(line);
            }
            rd.close();

            Map<String, Object> respMap = jsonToMap(result.toString()); // Pobranie calego jsona
            ArrayList<Object> respList = (ArrayList<Object>) respMap.get("list"); // Pobranie listy interwalow co 3 godziny


            LinkedTreeMap<String,Object> day0 = (LinkedTreeMap) respList.get(0); // Wybranie konkretnego interwalu
            LinkedTreeMap<String,Object> day1 = (LinkedTreeMap) respList.get(8);
            LinkedTreeMap<String,Object> day2 = (LinkedTreeMap) respList.get(16);
            LinkedTreeMap<String,Object> day3 = (LinkedTreeMap) respList.get(24);
            LinkedTreeMap<String,Object> day4 = (LinkedTreeMap) respList.get(32);
            LinkedTreeMap<String,Object> day5 = (LinkedTreeMap) respList.get(39);

            String[] labels = new String[16];

            // Today
            Map<String, Object> mainMap0 = jsonToMap(day0.get("main").toString());
            Map<String, Object> windMap0 = jsonToMap(day0.get("wind").toString());
            Map<String, Object> cityMap = jsonToMap(respMap.get("city").toString());
            ArrayList<Object> weatherList0 = (ArrayList<Object>) day0.get("weather");
            LinkedTreeMap<String,Object> cond0 = (LinkedTreeMap) weatherList0.get(0);

            labels[0] = "Lokalizacja: " + cityMap.get("name").toString();
            labels[1] = "Temperatura: " + mainMap0.get("temp").toString() + " C";
            labels[2] = "Wilgotność: " + mainMap0.get("humidity").toString() + " %";
            labels[3] = "Prędkość wiatru: " + windMap0.get("speed").toString() + " m/s";
            labels[4] = "Ciśnienie: " + mainMap0.get("pressure").toString() + " hPa";
            labels[10] = cond0.get("main").toString();

            // Day 1
            Map<String, Object> mainMap1 = jsonToMap(day1.get("main").toString());
            ArrayList<Object> weatherList1 = (ArrayList<Object>) day1.get("weather");
            LinkedTreeMap<String,Object> cond1 = (LinkedTreeMap) weatherList1.get(0);
            labels[11] = cond1.get("main").toString();

            // Day 2
            Map<String, Object> mainMap2 = jsonToMap(day2.get("main").toString());
            ArrayList<Object> weatherList2 = (ArrayList<Object>) day2.get("weather");
            LinkedTreeMap<String,Object> cond2 = (LinkedTreeMap) weatherList2.get(0);
            labels[12] = cond2.get("main").toString();

            // Day 3
            Map<String, Object> mainMap3 = jsonToMap(day3.get("main").toString());
            ArrayList<Object> weatherList3 = (ArrayList<Object>) day3.get("weather");
            LinkedTreeMap<String,Object> cond3 = (LinkedTreeMap) weatherList3.get(0);
            labels[13] = cond3.get("main").toString();

            // Day 4
            Map<String, Object> mainMap4 = jsonToMap(day4.get("main").toString());
            ArrayList<Object> weatherList4 = (ArrayList<Object>) day4.get("weather");
            LinkedTreeMap<String,Object> cond4 = (LinkedTreeMap) weatherList4.get(0);
            labels[14] = cond4.get("main").toString();

            // Day 5
            Map<String, Object> mainMap5 = jsonToMap(day5.get("main").toString());
            ArrayList<Object> weatherList5 = (ArrayList<Object>) day5.get("weather");
            LinkedTreeMap<String,Object> cond5 = (LinkedTreeMap) weatherList5.get(0);
            labels[15] = cond5.get("main").toString();


//            Map<String, Object> mainMap2 = jsonToMap(day2.get("main").toString());
//            Map<String, Object> mainMap3 = jsonToMap(day3.get("main").toString());
//            Map<String, Object> mainMap4 = jsonToMap(day4.get("main").toString());
//            Map<String, Object> mainMap5 = jsonToMap(day5.get("main").toString());

            labels[5] = "  " + mainMap1.get("temp").toString() + " C";
            labels[6] = "  " + mainMap2.get("temp").toString() + " C";
            labels[7] = "  " + mainMap3.get("temp").toString() + " C";
            labels[8] = "  " + mainMap4.get("temp").toString() + " C";
            labels[9] = "  " + mainMap5.get("temp").toString() + " C";

            labels[15] = "Extreme";

            return labels;

        } catch(IOException e) {

        }
        return null;
    }

    public static Map<String, Object> jsonToMap(String str){
        Map<String, Object> map = new Gson().fromJson(
                str, new TypeToken<HashMap<String, Object>>() {}.getType()
        );
        return map;
    }

    public static List<Object> jsonToList(String str){
        List<Object> list = new Gson().fromJson(
                str, new TypeToken<ArrayList<String>>() {}.getType()
        );
        return list;
    }

    String example2 = "https://api.openweathermap.org/data/2.5/forecast?lat=51.1&lon=17.03&cnt=40&units=metric&appid=5206d5fba284697c4b787b6c7e229acb";
    String site = "https://api.openweathermap.org/data/2.5/forecast?";
    String apiKey = "&cnt=40&units=metric&appid=5206d5fba284697c4b787b6c7e229acb";

    //            ArrayList<Object> respList = (ArrayList<Object>) respMap.get("list");
    //            Object obj0 = jsonToMap(respList.get(0).toString());
    //            Map<String, Object> mainMap = jsonToMap(obj0.get("main").toString());
    //            System.out.println("Temperature: " + (mainMap.get("temp")));


    //            List<Object> respList = jsonToList(respMap.get("list").toString());
    //            Map<String, Object> testMap = jsonToMap(respList.get(0).toString());
    //            Map<String, Object> mainMap = jsonToMap(testMap.get("main").toString());
    //            System.out.println("Current Temperature: " + (mainMap.get("temp")));

    //            labels[0] = "Location: " + (respMap.get("name"));
    //            labels[1] = "Temperature: " + (mainMap.get("temp"));
    //            labels[2] = "Humidity: " + (mainMap.get("humidity"));
    //            labels[3] = "Wind Speed: " + (windMap.get("speed"));
    //            labels[4] = "Wind Angle: " + (windMap.get("deg"));

    //            System.out.println("Location: " + (respMap.get("name")));
    //            System.out.println("Current Temperature: " + (mainMap.get("temp")));
    //            System.out.println("Current Humidity: " + mainMap.get("humidity"));
    //            System.out.println("Wind Speeds: " + windMap.get("speed"));
    //            System.out.println("Wind Angle: " + windMap.get("deg"));
}
