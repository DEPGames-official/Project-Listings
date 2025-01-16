import 'package:flutter/material.dart';

class PickerCarousel extends StatefulWidget {
  const PickerCarousel({super.key, required this.votingOptions, required this.onItemSelected});

  final List<dynamic> votingOptions;
  final Function(dynamic) onItemSelected;

  @override
  _PickerCarouselState createState() => _PickerCarouselState();
}

class _PickerCarouselState extends State<PickerCarousel> {
  int selectedNumber = 1;

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: 180,
      child: ListWheelScrollView(
        itemExtent: 45,
        diameterRatio: 1.5,
        offAxisFraction: 0,
        useMagnifier: false,
        magnification: 1.0,
        physics: const FixedExtentScrollPhysics(),
        children: widget.votingOptions.map((option) {
          return Center(
            child: Text(
              option,
              style: TextStyle(
                fontSize: option == widget.votingOptions[selectedNumber - 1] ? 40 : 24,
                color: option == widget.votingOptions[selectedNumber - 1] ? Colors.blue : Colors.black,
              ),
            ),
          );
        }).toList(),
        onSelectedItemChanged: (index) {
          setState(() {
            selectedNumber = index + 1;
            widget.onItemSelected(widget.votingOptions[selectedNumber - 1]);
          });
        },
      ),
    );
  }
}